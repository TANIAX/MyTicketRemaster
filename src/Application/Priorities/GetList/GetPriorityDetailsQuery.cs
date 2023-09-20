using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;

namespace MyTicketRemaster.Application.Priorities.GetList;

public record GetPriorityDetailsQuery : IRequest<PriorityDto>
{

}

public class GetPriorityListQueryHandler: IRequestHandler<ListQueryModel<PriorityDto>, IListResponseModel<PriorityDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPriorityListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IListResponseModel<PriorityDto>> Handle(ListQueryModel<PriorityDto> request, CancellationToken cancellationToken)
       => _unitOfWork.Priorities.GetProjectedListAsync(request, readOnly: true);
}