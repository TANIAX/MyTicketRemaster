using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.Update;

public record UpdateStoredReplyCommand : IRequest<StoredReply>
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Reply { get; set; } = null!;
    public class UpdateStoredReplyCommandHandler : IRequestHandler<UpdateStoredReplyCommand, StoredReply>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStoredReplyCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;
        

        public async Task<StoredReply> Handle(UpdateStoredReplyCommand request, CancellationToken cancellationToken)
        {
            var storedReply = await _unitOfWork.StoredReplies.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(StoredReply), request.Id);

            storedReply.UpdateTitle(request.Title.Trim());
            storedReply.UpdateReply(request.Reply.Trim());

            await _unitOfWork.SaveChanges();

            return storedReply;
        }
    }
}


