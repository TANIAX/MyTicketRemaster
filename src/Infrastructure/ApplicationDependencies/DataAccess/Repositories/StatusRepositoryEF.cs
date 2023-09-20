using MyTicketRemaster.Domain.Entities.Status;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class StatusRepositoryEF : RepositoryBaseEF<TStatus>, IStatusRepository
{
    protected override IQueryable<TStatus> BaseQuery
     => _context.Status;

    public StatusRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(TStatus entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<TStatus> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}