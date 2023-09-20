using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class ContactRepositoryEF : RepositoryBaseEF<TContact>, IContactRepository
{
    protected override IQueryable<TContact> BaseQuery
     => _context.Contacts;

    public ContactRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(TContact entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<TContact> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}