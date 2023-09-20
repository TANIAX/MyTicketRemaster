namespace MyTicketRemaster.Application.Priorities.Delete;
public class DeletePriorityCommandValidator : AbstractValidator<DeletePriorityCommand>
{
    public DeletePriorityCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}

