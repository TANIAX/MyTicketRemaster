using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;

namespace MyTicketRemaster.Application.Contacts.GetList;

public record GetContactListQuery : IRequest<ContactDto>
{

}

public class GetContactListQueryHandler : IRequestHandler<ListQueryModel<ContactDto>, IListResponseModel<ContactDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetContactListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IListResponseModel<ContactDto>> Handle(ListQueryModel<ContactDto> request, CancellationToken cancellationToken)
       => _unitOfWork.Contacts.GetProjectedListAsync(request, readOnly: true);
}