using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.Application.Status.Delete
{
    public record DeleteStatusCommand : IRequest<Unit>
    {
        public int Id { get; }
        public DeleteStatusCommand(int id)
            => Id = id;
        public class DeleteStatusCommandHandler : IRequestHandler<DeleteStatusCommand, Unit>
        {
            private readonly IUnitOfWork _unitOfWork;

            public DeleteStatusCommandHandler(IUnitOfWork unitOfWork)
                => _unitOfWork = unitOfWork;
            

            public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
            {
               var status = await _unitOfWork.Status.GetByIdAsync(request.Id)
                    ?? throw new EntityNotFoundException(nameof(TStatus),request.Id);

               _unitOfWork.Status.Remove(status);
                await _unitOfWork.SaveChanges();

                return Unit.Value;
            }
        }
    }
}

