using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Application.Priorities.Create;

public record CreatePriorityCommand : IRequest<Priority>
{
    public string Name { get; set; }
}

public class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand, Priority>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreatePriorityCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Priority> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
    {
        var priority = new Priority(
                request.Name.Trim(),
                true
            );

        _unitOfWork.Priorities.Add(priority);
        await _unitOfWork.SaveChanges();

        return priority;
    }
}