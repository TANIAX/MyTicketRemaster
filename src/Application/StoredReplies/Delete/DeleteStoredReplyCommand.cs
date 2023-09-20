using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.Delete;

public record DeleteStoredReplyCommand : IRequest<Unit>
{
    public int Id { get; }
    public DeleteStoredReplyCommand(int id)
        => Id = id;
    public class DeleteStoredReplyCommandHandler : IRequestHandler<DeleteStoredReplyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteStoredReplyCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;


        public async Task<Unit> Handle(DeleteStoredReplyCommand request, CancellationToken cancellationToken)
        {
            var storedReply = await _unitOfWork.StoredReplies.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(StoredReply), request.Id);

            _unitOfWork.StoredReplies.Remove(storedReply);
            await _unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }

}

