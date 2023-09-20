using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;

namespace MyTicketRemaster.Application.Groups.GetList;

public record GetGroupDetailsQuery : IRequest<GroupDto>
{

}

public class GetGroupListQueryHandler: IRequestHandler<ListQueryModel<GroupDto>, IListResponseModel<GroupDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGroupListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IListResponseModel<GroupDto>> Handle(ListQueryModel<GroupDto> request, CancellationToken cancellationToken)
       => _unitOfWork.Groups.GetProjectedListAsync(request, readOnly: true);
}