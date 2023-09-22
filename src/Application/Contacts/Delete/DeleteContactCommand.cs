using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Application.Contacts.Delete;

public record DeleteContactCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteContactCommand(int id)
        => Id = id;
}

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
{
    private IUnitOfWork _unitOfWork;

    public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
       var contact = await _unitOfWork.Contacts.GetByIdAsync(request.Id)
            ?? throw new EntityNotFoundException(nameof(TContact), request.Id);

        _unitOfWork.Contacts.Remove(contact);
        _unitOfWork.SaveChanges();

        return Unit.Value;

    }
}

