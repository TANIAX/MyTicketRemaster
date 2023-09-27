using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class CustomerRepositoryEF : RepositoryBaseEF<Customer>, ICustomerRepository
{
    protected override IQueryable<Customer> BaseQuery
     => _context.Customers;

    public CustomerRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(Customer entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<Customer> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }

    public async Task<Customer> GetCustomerByUserIdAsync(string userId)
     => await BaseQuery.SingleOrDefaultAsync(c => c.ApplicationUserId == userId);

    public async Task<Customer?> GetByEmailAsync(string email)
       => await BaseQuery.SingleOrDefaultAsync(e => e.Email == email);
}