
namespace MyTicketRemaster.Application.StoredReplies.Update;

public class UpdateStoredReplyCommandValidator : AbstractValidator<UpdateStoredReplyCommand>
{
    public UpdateStoredReplyCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(v => v.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(30).WithMessage("Name must not exceed 30 characters");

        RuleFor(v => v.Reply)
            .NotEmpty().WithMessage("Reply is required");
    }
}

