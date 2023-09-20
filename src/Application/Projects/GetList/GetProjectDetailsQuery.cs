using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;

namespace MyTicketRemaster.Application.Projects.GetList;

public record GetProjectDetailsQuery : IRequest<ProjectDto>
{

}

public class GetProjectListQueryHandler: IRequestHandler<ListQueryModel<ProjectDto>, IListResponseModel<ProjectDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Task<IListResponseModel<ProjectDto>> Handle(ListQueryModel<ProjectDto> request, CancellationToken cancellationToken)
       => _unitOfWork.Projects.GetProjectedListAsync(request, readOnly: true);
}