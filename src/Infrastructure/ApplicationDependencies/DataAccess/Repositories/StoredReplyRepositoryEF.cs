using MyTicketRemaster.Domain.Entities.StoredReplies;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class StoredReplyRepositoryEF : RepositoryBaseEF<StoredReply>, IStoredReplyRepository
{
    protected override IQueryable<StoredReply> BaseQuery
     => _context.StoredReplies;

    public StoredReplyRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(StoredReply entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<StoredReply> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}