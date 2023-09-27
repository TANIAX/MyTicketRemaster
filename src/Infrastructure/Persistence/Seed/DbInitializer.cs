using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyTicketRemaster.Domain.Entities.Users.Employees;
using MyTicketRemaster.Infrastructure.Identity.Model;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Infrastructure.Persistence.Settings;
using MyTicketRemaster.TestData;

namespace MyTicketRemaster.Infrastructure.Persistence.Seed;

static class DbInitializer
{
    public static void SeedDatabase(IApplicationBuilder appBuilder, IConfiguration configuration)
    {
        using (var scope = appBuilder.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            var settings = configuration.GetMyOptions<ApplicationDbSettings>();

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();

                if (settings.AutoMigrate == true && context.Database.IsSqlServer())
                {
                    context.Database.Migrate();
                }

                if (settings.AutoSeed == true)
                {
                    SeedDefaultUser(services, configuration.GetMyOptions<UserSeedSettings>());
                    SeedSampleData(context);
                }
            }
            catch (Exception exception)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<ApplicationDbContext>>();

                logger.LogError(exception, "An error occurred while migrating or seeding the database.");

                throw;
            }
        }
    }

    private static void SeedDefaultUser(IServiceProvider services, UserSeedSettings settings)
    {
        if (!settings.SeedDefaultUser)
            return;

        using (var userManager = services.GetRequiredService<UserManager<ApplicationUser>>())
        {
            if (!userManager.Users.Any(u => u.UserName == settings.DefaultUsername))
            {
                RoleManager<IdentityRole> roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                IdentityRole customerRole = new IdentityRole{ Name = "Customer" };
                IdentityRole employeeRole = new IdentityRole{ Name = "Employee" };
                IdentityRole adminRole = new IdentityRole{ Name = "Admin" };

                var customerRoleResult = roleManager.CreateAsync(customerRole).GetAwaiter().GetResult();
                if (!customerRoleResult.Succeeded)
                {
                    throw new Exception($"Customer role creation failed with the following errors: "
                        + customerRoleResult.Errors.Aggregate("", (sum, err) => sum += $"{Environment.NewLine} - {err.Description}"));
                }

                var employeeRoleResult = roleManager.CreateAsync(employeeRole).GetAwaiter().GetResult();
                if (!employeeRoleResult.Succeeded)
                {
                    throw new Exception($"Employee role creation failed with the following errors: "
                        + employeeRoleResult.Errors.Aggregate("", (sum, err) => sum += $"{Environment.NewLine} - {err.Description}"));
                }

                var adminRoleResult = roleManager.CreateAsync(adminRole).GetAwaiter().GetResult();
                if (!adminRoleResult.Succeeded)
                {
                    throw new Exception($"Admin role creation failed with the following errors: "
                        + adminRoleResult.Errors.Aggregate("", (sum, err) => sum += $"{Environment.NewLine} - {err.Description}"));
                }


                var defaultUser = new ApplicationUser { UserName = settings.DefaultUsername, Email = settings.DefaultEmail };
                var defaultResult = userManager.CreateAsync(defaultUser, settings.DefaultPassword).GetAwaiter().GetResult();
                if (!defaultResult.Succeeded)
                {
                    throw new Exception($"Default user creation failed with the following errors: "
                        + defaultResult.Errors.Aggregate("", (sum, err) => sum += $"{Environment.NewLine} - {err.Description}"));
                }
                else
                {
                    userManager.AddToRoleAsync(defaultUser, "Admin").GetAwaiter().GetResult();
                }


                var employee = new ApplicationUser { UserName = "employee", Email = "Employee123@my-ticket-remaster.be" };
                var employeeResult = userManager.CreateAsync(employee, employee.Email).GetAwaiter().GetResult();
                if (!employeeResult.Succeeded)
                {
                    throw new Exception($"Employee user creation failed with the following errors: "
                        + employeeResult.Errors.Aggregate("", (sum, err) => sum += $"{Environment.NewLine} - {err.Description}"));
                }
                else
                {
                    userManager.AddToRoleAsync(employee, "Employee").GetAwaiter().GetResult();
                }

                var customer = new ApplicationUser { UserName = "customer", Email = "Customer123@my-ticket-remaster.be" };
                var customerResult = userManager.CreateAsync(customer, customer.Email).GetAwaiter().GetResult();

                if (!customerResult.Succeeded)
                {
                    throw new Exception($"Customer user creation failed with the following errors: "
                        + customerResult.Errors.Aggregate("", (sum, err) => sum += $"{Environment.NewLine} - {err.Description}"));
                }
                else
                {
                    userManager.AddToRoleAsync(customer, "Customer").GetAwaiter().GetResult();
                }
            }
        }
    }

    private static void SeedSampleData(ApplicationDbContext context)
    {
        //If there are no projects, then seed the database because at least one project is required to run the application
        if (!context.Projects.Any())
        {
            //Get the sample data
            var (types, status, priorities, projects, groups, customers, employees, contacts) = DataGenerator.GenerateBaseEntities();

            //Seed the database with the rest of the sample data
           
            context.Types.AddRange(types);
            context.Status.AddRange(status);
            context.Priorities.AddRange(priorities);
            context.Projects.AddRange(projects);
            context.Groups.AddRange(groups);

            context.SaveChanges();

            //For the rest of the entities, we need to manually set some properties
            //Customer need to be mapped with a ApplicationUserId
            customers[0].UpdateApplicationUserId(context.Users.FirstOrDefault(u => u.UserName == "customer").Id);
            context.Customers.AddRange(customers);

            //Employee need to be mapped with a ApplicationUserId and Group entity

            employees[0].UpdateApplicationUserId(context.Users.FirstOrDefault(u => u.UserName == "employee").Id);
            employees[0].UpdateGroup(context.Groups.FirstOrDefault());
            context.Employees.AddRange(employees);

            context.SaveChanges();

            //Contact need to be mapped with a Customer entity
            contacts[0].UpdateCustomer(customers[0]);
            context.Contacts.AddRange(contacts);


            context.SaveChanges();

        }
    }
}
