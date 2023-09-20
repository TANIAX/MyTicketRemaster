using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.Projects.GetDetails;

public record GetProjectDetailsQuery : IRequest<ProjectDetailsDto>
{
    public int Id { get; set; }

    public GetProjectDetailsQuery(int id)
        => Id = id;
}

public class GetProjectDetailsQueryHandler : IRequestHandler<GetProjectDetailsQuery, ProjectDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetProjectDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ProjectDetailsDto> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.Projects.GetByIdAsync(request.Id)
            ?? throw new EntityNotFoundException(nameof(Project), request.Id);

        return _mapper.Map<ProjectDetailsDto>(project);
    }
}