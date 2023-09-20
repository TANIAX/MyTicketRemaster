namespace MyTicketRemaster.Application.Types.Delete;

public class DeleteTypeCommandValidator : AbstractValidator<DeleteTypeCommand>
{
    public DeleteTypeCommandValidator()
    {
        RuleFor(v => v.Id)
            .NotEmpty().WithMessage("Id is required");
    }
}

