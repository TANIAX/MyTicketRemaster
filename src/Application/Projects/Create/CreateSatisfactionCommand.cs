using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.Projects.Create;

public record CreateProjectCommand : IRequest<Project>
{
    public string Name { get; init; } = null!;
}

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Project>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Project> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project(
                request.Name.Trim(),
                true
            );

        _unitOfWork.Projects.Add(project);
        await _unitOfWork.SaveChanges();

        return project;
    }
}