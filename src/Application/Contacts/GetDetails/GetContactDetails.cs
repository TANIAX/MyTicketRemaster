using MyTicketRemaster.Application.Common.Dependencies.DataAccess;

namespace MyTicketRemaster.Application.Contacts.GetDetails;

public record GetContactDetailsQuery : IRequest<ContactDetailsDto>
{
    public int Id { get; set; }
}

public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsQuery, ContactDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetContactDetailsQueryHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public Task<ContactDetailsDto> Handle(GetContactDetailsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}