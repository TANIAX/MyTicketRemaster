
using MyTicketRemaster.Application.Groups.Create;

namespace MyTicketRemaster.Application.Groups.Create
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
        }
    }
}
