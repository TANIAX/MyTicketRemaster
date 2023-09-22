using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Application.Priorities.Create;

public class CreatePriorityCommandValidator : AbstractValidator<CreatePriorityCommand>
{
    public CreatePriorityCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(PriorityInvariants.NameMaxLength).WithMessage($"Name must not exceed {PriorityInvariants.NameMaxLength} characters");
    }
}
