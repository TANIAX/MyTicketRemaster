using MyTicketRemaster.Infrastructure.Authentication.Core.Model;
using MyTicketRemaster.Infrastructure.Authentication.External.Model;

namespace MyTicketRemaster.Infrastructure.Authentication.External.Services;

public interface IExternalSignInService
{
    Task<(MySignInResult result, SignInData? data)> SignInExternal(ExternalAuthenticationProvider provider, string idToken);
}
