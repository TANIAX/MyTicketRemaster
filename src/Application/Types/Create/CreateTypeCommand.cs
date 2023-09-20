using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Types;


namespace MyTicketRemaster.Application.Types.Create;

public record CreateTypeCommand : IRequest<TType>
{
    public string Name { get; init; } = null!;
}

public class CreateTypeCommandHandler : IRequestHandler<CreateTypeCommand, TType>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTypeCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<TType> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
    {
        var type = new TType(
                request.Name.Trim()
            );

        _unitOfWork.Types.Add(type);
        await _unitOfWork.SaveChanges();

        return type;
    }
}