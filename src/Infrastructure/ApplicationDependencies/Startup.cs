using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;
using MyTicketRemaster.Application.Dependencies.Services;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.Services;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies;

[ExcludeFromCodeCoverage]
internal static class Startup
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration _)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IGroupRepository, GroupRepositoryEF>();
        services.AddScoped<IProjectRepository, ProjectRepositoryEF>();
        services.AddScoped<IStatusRepository, StatusRepositoryEF>();
        services.AddScoped<ITypeRepository, TypeRepositoryEF>();
        services.AddScoped<IPriorityRepository, PriorityRepositoryEF>();
        services.AddScoped<IStoredReplyRepository, StoredReplyRepositoryEF>();
        services.AddScoped<IEmployeeRepository, EmployeeRepositoryEF>();
        services.AddScoped<IContactRepository, ContactRepositoryEF>();
        services.AddScoped<ICustomerRepository, CustomerRepositoryEF>();

        services.AddTransient<IDateTime, DateTimeService>();
    }
}
