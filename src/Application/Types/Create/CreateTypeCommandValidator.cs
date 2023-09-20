
using MyTicketRemaster.Application.Types.Create;

namespace MyTicketRemaster.Application.Types.Create
{
    public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
    {
        public CreateTypeCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
        }
    }
}
