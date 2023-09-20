using MyTicketRemaster.Domain.Entities.Priorities;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class PriorityRepositoryEF : RepositoryBaseEF<Priority>, IPriorityRepository
{
    protected override IQueryable<Priority> BaseQuery
     => _context.Priorities;

    public PriorityRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(Priority entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<Priority> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}