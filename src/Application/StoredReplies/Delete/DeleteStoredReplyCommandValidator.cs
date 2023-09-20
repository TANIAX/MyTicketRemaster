namespace MyTicketRemaster.Application.StoredReplies.Delete;
public class DeleteStoredReplyCommandValidator : AbstractValidator<DeleteStoredReplyCommand>
{
    public DeleteStoredReplyCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}

