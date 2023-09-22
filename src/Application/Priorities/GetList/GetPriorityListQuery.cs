using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Priorities.GetList;

namespace MyTicketRemaster.Application.Prioritys.GetList;

public record GetPriorityListQuery : IRequest<PriorityDto>
{

}

public class GetPriorityListQueryHandler : IRequestHandler<ListQueryModel<PriorityDto>, IListResponseModel<PriorityDto>>
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