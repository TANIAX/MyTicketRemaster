using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Common.Dependencies.Services
{
    public interface IIdentityService
    {
        Task<bool> UserExist(string userId);
        Task<bool> RoleExist(string roleName);
        Task<string> GetUserNameAsync(string userId);
        Task<(bool result, string UserId)> CreateUserAsync(string userName, string password, string role);
        Task<bool> DeleteUserAsync(string userId);
        Task<bool> SetPassword(string userId, string password);
        Task<object> FindByEmailAsync(string email);
        Task<bool> ResetPasswordAsync(object user, string token, string newPassword);
        Task<bool> CreateAsync(object user, string password);
        Task<bool> AddToRoleAsync(object user, string role);
        Task<bool> DeleteAsync(object user);
        Task<string> GeneratePasswordResetTokenAsync(object user);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<IList<object>> UsersInRoleAsync(string role);

    }
}
