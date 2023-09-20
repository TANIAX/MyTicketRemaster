namespace MyTicketRemaster.Application.Priorities.Create;

public class CreatePriorityCommandValidator : AbstractValidator<CreatePriorityCommand>
{
    public CreatePriorityCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
    }
}
