using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.GetDetails;

public record GetGroupDetailsQuery : IRequest<GroupDetailsDto>
{
    public int Id { get; set; }

    public GetGroupDetailsQuery(int id)
        => Id = id;
}

public class GetGroupDetailsQueryHandler : IRequestHandler<GetGroupDetailsQuery, GroupDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetGroupDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GroupDetailsDto> Handle(GetGroupDetailsQuery request, CancellationToken cancellationToken)
    {
        var group = await _unitOfWork.Groups.GetByIdAsync(request.Id)
            ?? throw new EntityNotFoundException(nameof(TGroup), request.Id);

        return _mapper.Map<GroupDetailsDto>(group);
    }
}