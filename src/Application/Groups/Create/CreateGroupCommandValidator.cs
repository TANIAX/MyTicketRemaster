
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.Create
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(GroupInvariants.NameMaxLength).WithMessage($"Name must not exceed {GroupInvariants.NameMaxLength} characters");
        }
    }
}
