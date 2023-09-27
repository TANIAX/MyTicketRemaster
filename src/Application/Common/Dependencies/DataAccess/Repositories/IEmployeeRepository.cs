using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

public interface IEmployeeRepository : IRepository<Employee>
{
    Task<Employee> GetEmployeeByUserIdAsync(string userId);
    Task<Employee?> GetByEmailAsync(string email);
}