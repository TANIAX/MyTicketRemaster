using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.Delete;

public record DeleteGroupCommand : IRequest<Unit>
{
    public int Id { get; }
    public DeleteGroupCommand(int id)
        => Id = id;
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteGroupCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;


        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _unitOfWork.Groups.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(TGroup), request.Id);

            _unitOfWork.Groups.Remove(group);
            await _unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}


