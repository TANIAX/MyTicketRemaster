
namespace MyTicketRemaster.Application.Priorities.Update;

public class UpdatePriorityCommandValidator : AbstractValidator<UpdatePriorityCommand>
{
    public UpdatePriorityCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
    }
}

