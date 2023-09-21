using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Statuss.GetStatusGetStatusList;

namespace MyTicketRemaster.Application.Statuss.GetStatusList;

public record GetStatusDetailsQuery : IRequest<StatusDto>
{

}

public class GetStatusListQueryHandler: IRequestHandler<ListQueryModel<StatusDto>, IListResponseModel<StatusDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetStatusListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IListResponseModel<StatusDto>> Handle(ListQueryModel<StatusDto> request, CancellationToken cancellationToken)
       => _unitOfWork.Status.GetProjectedListAsync(request, readOnly: true);
}