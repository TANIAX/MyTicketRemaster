using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Application.Contacts.Create;
public record CreateContactCommand : IRequest<TContact>
{
}

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, TContact>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public Task<TContact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}   