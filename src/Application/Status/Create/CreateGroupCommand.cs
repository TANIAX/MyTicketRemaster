using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Status;


namespace MyTicketRemaster.Application.Statuss.CreateStatus;

public record CreateStatusCommand : IRequest<TStatus>
{
    public string Name { get; init; } = null!;
}

public class CreateStatusCommandHandler : IRequestHandler<CreateStatusCommand, TStatus>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateStatusCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<TStatus> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        var status = new TStatus(
                request.Name.Trim()
            );

        _unitOfWork.Status.Add(status);
        await _unitOfWork.SaveChanges();

        return status;
    }
}