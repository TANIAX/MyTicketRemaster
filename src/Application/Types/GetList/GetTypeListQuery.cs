using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Types.GetList;

namespace MyTicketRemaster.Application.Types.GetTypeList;

public record GetTypeListQuery : IRequest<TypeDto>
{

}

public class GetTypeListQueryHandler : IRequestHandler<ListQueryModel<TypeDto>, IListResponseModel<TypeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTypeListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IListResponseModel<TypeDto>> Handle(ListQueryModel<TypeDto> request, CancellationToken cancellationToken)
       => _unitOfWork.Types.GetProjectedListAsync(request, readOnly: true);
}