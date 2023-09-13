using MyTicketRemaster.Application.Dependencies.Services;
using MyTicketRemaster.WebApi.Authentication.Services;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.WebApi.Authentication;

[ExcludeFromCodeCoverage]
internal static class AuthenticationStartup
{
    public static void AddMyApiAuthDeps(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();
    }
}
