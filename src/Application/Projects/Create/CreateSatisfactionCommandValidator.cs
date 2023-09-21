using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.Projects.Create;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(ProjectInvariants.NameMaxLength).WithMessage($"Name must not exceed {ProjectInvariants.NameMaxLength} characters");
    }
}
