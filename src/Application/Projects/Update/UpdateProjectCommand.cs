using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.Projects.Update;

public record UpdateProjectCommand : IRequest<Project>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Project>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Project> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(Project), request.Id);

            project.UpdateName(request.Name.Trim());
            project.Editable = true;

            await _unitOfWork.SaveChanges();

            return project;
        }
    }
}


