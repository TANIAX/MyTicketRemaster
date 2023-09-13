using MyTicketRemaster.Infrastructure.Authentication.External.Model;
using System.Diagnostics.CodeAnalysis;

namespace MyTicketRemaster.Infrastructure.Authentication.External.Services;

public interface IExternalAuthenticationVerifier
{
    Task<(bool success, ExternalUserData? userData)> Verify(ExternalAuthenticationProvider provider, string idToken);
}
