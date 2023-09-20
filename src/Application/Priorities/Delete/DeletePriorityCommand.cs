using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Application.Priorities.Delete;

public record DeletePriorityCommand : IRequest<Unit>
{
    public int Id { get; }
    public DeletePriorityCommand(int id)
        => Id = id;
    public class DeletePriorityCommandHandler : IRequestHandler<DeletePriorityCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePriorityCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;


        public async Task<Unit> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
        {
            var priority = await _unitOfWork.Priorities.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(Priority), request.Id);

            _unitOfWork.Priorities.Remove(priority);
            await _unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }

}

