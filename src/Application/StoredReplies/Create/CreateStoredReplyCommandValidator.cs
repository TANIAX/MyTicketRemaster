using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.Create;

public class CreateStoredReplyCommandValidator : AbstractValidator<CreateStoredReplyCommand>
{
    public CreateStoredReplyCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(StoredReplyInvariants.TitleMaxLength).WithMessage($"Title must not exceed {StoredReplyInvariants.TitleMaxLength} characters");
    }
}
