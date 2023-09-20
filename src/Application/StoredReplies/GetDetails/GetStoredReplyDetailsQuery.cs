using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.GetDetails;

public record GetStoredReplyDetailsQuery : IRequest<StoredReplyDetailsDto>
{
    public int Id { get; set; }

    public GetStoredReplyDetailsQuery(int id)
        => Id = id;
}

public class GetStoredReplyDetailsQueryHandler : IRequestHandler<GetStoredReplyDetailsQuery, StoredReplyDetailsDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetStoredReplyDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<StoredReplyDetailsDto> Handle(GetStoredReplyDetailsQuery request, CancellationToken cancellationToken)
    {
        var storedReply = await _unitOfWork.StoredReplies.GetByIdAsync(request.Id)
            ?? throw new EntityNotFoundException(nameof(StoredReply), request.Id);

        return _mapper.Map<StoredReplyDetailsDto>(storedReply);
    }
}