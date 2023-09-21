using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Groups;


namespace MyTicketRemaster.Application.Groups.Create;

public record CreateGroupCommand : IRequest<TGroup>
{
    public string Name { get; set; }
}

public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, TGroup>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateGroupCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<TGroup> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var group = new TGroup(
                request.Name.Trim()
            );

        _unitOfWork.Groups.Add(group);
        await _unitOfWork.SaveChanges();

        return group;
    }
}