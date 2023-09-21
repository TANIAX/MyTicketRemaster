namespace MyTicketRemaster.Application.Contacts.Delete;

public record DeleteContactCommand : IRequest<Unit>
{

}

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
{
    public Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

