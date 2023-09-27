using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

public interface ICustomerRepository : IRepository<Customer>
{
    Task<Customer> GetCustomerByUserIdAsync(string userId);
    Task<Customer?> GetByEmailAsync(string email);
}