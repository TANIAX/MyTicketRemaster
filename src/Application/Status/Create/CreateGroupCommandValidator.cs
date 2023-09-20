using MyTicketRemaster.Application.Statuss.CreateStatus;

namespace MyTicketRemaster.Application.Status.Commands.Create
{
    public class CreateStatusCommandValidator : AbstractValidator<CreateStatusCommand>
    {
        public CreateStatusCommandValidator()
        {
            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(30).WithMessage("Name must not exceed 30 characters");
        }
    }
}
