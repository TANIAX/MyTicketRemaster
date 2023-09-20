using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.Create;

public record CreateStoredReplyCommand : IRequest<StoredReply>
{
    public string Title { get; init; } = null!;
    public string Reply { get; init; } = null!;
}

public class CreateStoredReplyCommandHandler : IRequestHandler<CreateStoredReplyCommand, StoredReply>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStoredReplyCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<StoredReply> Handle(CreateStoredReplyCommand request, CancellationToken cancellationToken)
    {
        var storedReply = new StoredReply(
                request.Title.Trim(),
                request.Reply.Trim()
            );

        _unitOfWork.StoredReplies.Add(storedReply);
        await _unitOfWork.SaveChanges();

        return storedReply;
    }
}