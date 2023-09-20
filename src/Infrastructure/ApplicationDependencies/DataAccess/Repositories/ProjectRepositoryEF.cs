using MyTicketRemaster.Domain.Entities.Projects;
using MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Infrastructure.Persistence.Context;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories;

namespace MyTicketRemaster.Infrastructure.ApplicationDependencies.DataAccess.Repositories;

internal class ProjectRepositoryEF : RepositoryBaseEF<Project>, IProjectRepository
{
    protected override IQueryable<Project> BaseQuery
     => _context.Projects;

    public ProjectRepositoryEF(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
    { 
        
    }

    public override void Remove(Project entityToDelete)
    {
        _context.Remove(entityToDelete);
    }

    public override void RemoveRange(IEnumerable<Project> entitiesToDelete)
    {
        foreach (var e in entitiesToDelete)
            Remove(e);
    }
}