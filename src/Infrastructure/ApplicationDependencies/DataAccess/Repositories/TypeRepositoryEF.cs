using MyTicketRemaster.Domain.Entities.Types;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class TypeRepositoryEF : RepositoryBaseEF<TType>, ITypeRepository
{
    protected override IQueryable<TType> BaseQuery
     => _context.Types;

    public TypeRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(TType entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<TType> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}