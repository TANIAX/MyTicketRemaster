using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.Application.Statuss.GetStatusDetails;

public record GetStatusDetailsQuery : IRequest<StatusDetailsDto>
{
    public int Id { get; set; }

    public GetStatusDetailsQuery(int id)
        => Id = id;
}

public class GetStatusDetailsQueryHandler : IRequestHandler<GetStatusDetailsQuery, StatusDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetStatusDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<StatusDetailsDto> Handle(GetStatusDetailsQuery request, CancellationToken cancellationToken)
    {
        var status = await _unitOfWork.Status.GetByIdAsync(request.Id)
           ?? throw new EntityNotFoundException(nameof(TStatus), request.Id);

        return _mapper.Map<StatusDetailsDto>(status);
    }
}