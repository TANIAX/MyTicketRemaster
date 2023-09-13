using MyTicketRemaster.Infrastructure.Authentication.Core.Model;

namespace MyTicketRemaster.Infrastructure.Authentication.Core.Services;

public interface IUserService
{
    Task<(MySignInResult result, SignInData? data)> SignIn(string username, string password);
}
