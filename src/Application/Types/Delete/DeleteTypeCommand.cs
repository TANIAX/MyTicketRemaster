using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.Delete;

public record DeleteTypeCommand : IRequest<Unit>
{
    public int Id { get; }
    public DeleteTypeCommand(int id)
        => Id = id;
    public class DeleteTypeCommandHandler : IRequestHandler<DeleteTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTypeCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;


        public async Task<Unit> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var type = await _unitOfWork.Types.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(TType), request.Id);

            _unitOfWork.Types.Remove(type);
            await _unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}


