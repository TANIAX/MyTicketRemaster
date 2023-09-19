using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class GroupRepositoryEF : RepositoryBaseEF<TGroup>, IGroupRepository
{
    protected override IQueryable<TGroup> BaseQuery
     => _context.Groups;

    public GroupRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(TGroup entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<TGroup> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}