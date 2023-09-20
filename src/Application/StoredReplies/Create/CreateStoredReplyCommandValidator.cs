namespace MyTicketRemaster.Application.StoredReplies.Create;

public class CreateStoredReplyCommandValidator : AbstractValidator<CreateStoredReplyCommand>
{
    public CreateStoredReplyCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(30).WithMessage("Title must not exceed 30 characters");
    }
}
