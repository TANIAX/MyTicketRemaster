using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;

namespace MyTicketRemaster.Application.Projects.GetList;

public record GetProjectListQuery : IRequest<ProjectDto>
{
    public int Id { get; set; }
  
    public GetProjectListQuery(int id)
        => Id = id;
}

public class GetProjectListQueryHandler: IRequestHandler<ListQueryModel<ProjectDto>, IListResponseModel<ProjectDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetProjectListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        => _unitOfWork = unitOfWork;


    public Task<IListResponseModel<ProjectDto>> Handle(ListQueryModel<ProjectDto> request, CancellationToken cancellationToken)
       => _unitOfWork.Projects.GetProjectedListAsync(request, readOnly: true);
}