namespace MyTicketRemaster.Application.Status.Delete
{
    public class DeleteStatusCommandValidator : AbstractValidator<DeleteStatusCommand>
    {
        public DeleteStatusCommandValidator()
        {
            RuleFor(v => v.Id)
                .NotEmpty().WithMessage("Id is required");
        }
    }
}
