using MyTicketRemaster.WebApi.Logging;
using MyTicketRemaster.WebApi.ErrorHandling;
using MyTicketRemaster.WebApi.CORS;
using MyTicketRemaster.Infrastructure;
using MyTicketRemaster.Application;
using MyTicketRemaster.WebApi.Authentication;
using MyTicketRemaster.WebApi.Swagger;
using MyTicketRemaster.WebApi.Versioning;

namespace MyTicketRemaster.WebApi;

[ExcludeFromCodeCoverage]
public class Startup
{
    protected IConfiguration Configuration { get; }
    protected IWebHostEnvironment Environment { get; }

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        => (Configuration, Environment) = (configuration, environment);

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMyApi();
        services.AddMyApiAuthDeps();
        services.AddMyErrorHandling();
        services.AddMySwagger(Configuration);
        services.AddMyVersioning();
        services.AddMyCorsConfiguration(Configuration);
        services.AddMyInfrastructureDependencies(Configuration, Environment);
        services.AddMyApplicationDependencies();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseMyRequestLogging();
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseMyCorsConfiguration();
        app.UseMySwagger(Configuration);
        app.UseMyInfrastructure(Configuration, Environment);
        app.UseMyApi();
    }
}
