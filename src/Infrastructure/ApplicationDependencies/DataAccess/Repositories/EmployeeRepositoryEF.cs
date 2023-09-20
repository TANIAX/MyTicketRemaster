using MyTicketRemaster.Domain.Entities.Users.Employees;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class EmployeeRepositoryEF : RepositoryBaseEF<Employee>, IEmployeeRepository
{
    protected override IQueryable<Employee> BaseQuery
     => _context.Employees;

    public EmployeeRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(Employee entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<Employee> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}