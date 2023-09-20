using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.Projects.Delete;

public record DeleteProjectCommand : IRequest<Unit>
{
    public int Id { get; }
    public DeleteProjectCommand(int id)
        => Id = id;
    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProjectCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;


        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(Project), request.Id);

            _unitOfWork.Projects.Remove(project);
            await _unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }

}

