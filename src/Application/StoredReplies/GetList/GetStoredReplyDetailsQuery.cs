using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;

namespace MyTicketRemaster.Application.StoredReplies.GetList;

public record GetStoredReplyDetailsQuery : IRequest<StoredReplyDto>
{

}

public class GetStoredReplyListQueryHandler: IRequestHandler<ListQueryModel<StoredReplyDto>, IListResponseModel<StoredReplyDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetStoredReplyListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IListResponseModel<StoredReplyDto>> Handle(ListQueryModel<StoredReplyDto> request, CancellationToken cancellationToken)
       => _unitOfWork.StoredReplies.GetProjectedListAsync(request, readOnly: true);
}