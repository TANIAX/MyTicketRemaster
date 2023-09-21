
using MyTicketRemaster.Application.Types.Create;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.Create
{
    public class CreateTypeCommandValidator : AbstractValidator<CreateTypeCommand>
    {
        public CreateTypeCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(TypeInvariants.NameMaxLength).WithMessage($"Name must not exceed {TypeInvariants.NameMaxLength} characters");
        }
    }
}
