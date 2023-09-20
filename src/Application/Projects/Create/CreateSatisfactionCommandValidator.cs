namespace MyTicketRemaster.Application.Projects.Create;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
    }
}
