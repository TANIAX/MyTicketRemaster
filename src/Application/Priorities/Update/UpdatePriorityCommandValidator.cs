
using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Application.Priorities.Update;

public class UpdatePriorityCommandValidator : AbstractValidator<UpdatePriorityCommand>
{
    public UpdatePriorityCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(PriorityInvariants.NameMaxLength).WithMessage($"Name must not exceed {PriorityInvariants.NameMaxLength} characters");
    }
}

