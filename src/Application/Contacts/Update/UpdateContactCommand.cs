using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Application.Contacts.Update;

public record UpdateContactCommand : IRequest<TContact>
{

}
public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, TContact>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public Task<TContact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
