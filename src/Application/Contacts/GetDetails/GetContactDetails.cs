using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Application.Contacts.GetDetails;

public record GetContactDetailsQuery : IRequest<ContactDetailsDto>
{
    public int Id { get; set; }

    public GetContactDetailsQuery(int id)
        => Id = id;
}

public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsQuery, ContactDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetContactDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
       

    public async Task<ContactDetailsDto> Handle(GetContactDetailsQuery request, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(request.Id)
            ?? throw new EntityNotFoundException(nameof(TContact), request.Id);


        return _mapper.Map<ContactDetailsDto>(contact);
    }
}