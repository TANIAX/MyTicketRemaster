
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyTicketRemaster.Application.Common.Dependencies.Services;
using MyTicketRemaster.Domain.Entities.Users.Employees;
using MyTicketRemaster.Infrastructure.Identity.Model;



namespace MyTicketRemaster.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(UserManager<ApplicationUser> userManager)
            => _userManager = userManager;


        public async Task<bool> UserExist(string userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);

            return user != null;
        }

        public async Task<bool> RoleExist(string roleName)
        { 
            return await _roleManager.RoleExistsAsync(roleName);
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            if (userId == null)
                return null;

            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }

        public async Task<(bool result, string UserId)> CreateUserAsync(string userName, string password, string role)
        {
            //Check if role exists, if not create it
            if (!await RoleExist(role))
            {
                IdentityRole customerRole = new IdentityRole { Name = role };
                await _roleManager.CreateAsync(customerRole);
            }


            //Create user
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new Exception("Failed to create user");

            //Add user to role
            await _userManager.AddToRoleAsync(user, role);


            return (result.Succeeded, user.Id);
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user == null)
                throw new Exception("User not found");

            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }


        public async Task<object> FindByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<bool> SetPassword(string userId, string password)
        {
            var user = (ApplicationUser)await FindByIdAsync(userId);
            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, password);
            if (!result.Succeeded)
                throw new Exception("Failed to set password");

            return result.Succeeded;
        }


        public async Task<object> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> ResetPasswordAsync(object user, string token, string newPassword)
        {
            var result = await _userManager.ResetPasswordAsync((ApplicationUser)user, token, newPassword);
            if (!result.Succeeded)
                throw new Exception("Failed to reset password");

            return result.Succeeded;
        }

        public async Task<bool> CreateAsync(object user, string password)
        {
            var result = await _userManager.CreateAsync((ApplicationUser)user, password);
            if (!result.Succeeded)
                throw new Exception("Failed to create user");

            return result.Succeeded;
        }

        public async Task<bool> AddToRoleAsync(object user, string role)
        {
            var result = await _userManager.AddToRoleAsync((ApplicationUser)user, role);
            if (!result.Succeeded)
                throw new Exception("Failed to add user to role");

            return result.Succeeded;
        }
        public async Task<bool> DeleteAsync(object user)
        {
            var result = await _userManager.DeleteAsync((ApplicationUser)user);
            if (!result.Succeeded)
                throw new Exception("Failed to delete user");

            return result.Succeeded;
        }

        public async Task<string> GeneratePasswordResetTokenAsync(object user)
        {
            return await _userManager.GeneratePasswordResetTokenAsync((ApplicationUser)user);
        }

        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            return await _userManager.IsInRoleAsync((ApplicationUser)await FindByIdAsync(userId), role);
        }

        public async Task<IList<object>> UsersInRoleAsync(string role)
        {
           var result = await _userManager.GetUsersInRoleAsync(role);
           var transformedResult = new List<object>();
            foreach (var user in result)
            {
                transformedResult.Add((object) user);
            }
            return transformedResult;
        }
    }
}