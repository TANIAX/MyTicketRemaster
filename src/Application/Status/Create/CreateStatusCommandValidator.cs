using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.Application.Status.Create;

public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
{
    public CreateStatusCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(StatusInvariants.NameMaxLength).WithMessage($"Name must not exceed {StatusInvariants.NameMaxLength} characters");
    }
}

