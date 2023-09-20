using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Application.Types.GetDetails;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Type.GetDetails;

public record GetTypeDetailsQuery : IRequest<TypeDetailsDto>
{
    public int Id { get; set; }

    public GetTypeDetailsQuery(int id)
        => Id = id;
}

public class GetTypeDetailsQueryHandler : IRequestHandler<GetTypeDetailsQuery, TypeDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTypeDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TypeDetailsDto> Handle(GetTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var type = await _unitOfWork.Types.GetByIdAsync(request.Id)
            ?? throw new EntityNotFoundException(nameof(TType), request.Id);

        return _mapper.Map<TypeDetailsDto>(type);
    }
}