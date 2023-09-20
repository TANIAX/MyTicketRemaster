using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Application.Priorities.GetDetails;

public record GetPriorityDetailsQuery : IRequest<PriorityDetailsDto>
{
    public int Id { get; set; }

    public GetPriorityDetailsQuery(int id)
        => Id = id;
}

public class GetPriorityDetailsQueryHandler : IRequestHandler<GetPriorityDetailsQuery, PriorityDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPriorityDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PriorityDetailsDto> Handle(GetPriorityDetailsQuery request, CancellationToken cancellationToken)
    {
        var priority = await _unitOfWork.Priorities.GetByIdAsync(request.Id)
            ?? throw new EntityNotFoundException(nameof(Priority), request.Id);

        return _mapper.Map<PriorityDetailsDto>(priority);
    }
}