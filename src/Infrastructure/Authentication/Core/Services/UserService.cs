using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Azure;
using MyTicketRemaster.Infrastructure.Authentication.Core.Model;
using MyTicketRemaster.Infrastructure.Identity.Model;
using System.Data;
using System.Security.Claims;

namespace MyTicketRemaster.Infrastructure.Authentication.Core.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ITokenService _tokenService;

    public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<(MySignInResult result, SignInData? data)> SignIn(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return (MySignInResult.Failed, null);
        }

        // Don't use SignInManager.PasswordSignInAsync(), because that sets useless cookies.
        // But 'CheckPasswordSignInAsync' doesn't. Yep, it's confusing. Good thing we have access to the source code. :D
        var result = await _signInManager.CheckPasswordSignInAsync(user, password, true);

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
                return (MySignInResult.LockedOut, null);
            if (result.IsNotAllowed)
                return (MySignInResult.NotAllowed, null);
            throw new System.Exception("Unhandled sign-in outcome.");
        }
        
        // Get userRole
        var userRole = await _userManager.GetRolesAsync(user);
        //Fixme
        //IEnumerable<(string claimType, string claimValue)> customClaims = new List<(string, string)>()
        //{
        //    (ClaimTypes.Role, "Admin"),
        //};
       

        //Create 
        var token = _tokenService.CreateAuthenticationToken(user.Id, username);

        return (
            MySignInResult.Success,
            data: new SignInData()
            {
                Username = user.UserName,
                Email = user.Email,
                Token = token
            }
        );
    }
}
