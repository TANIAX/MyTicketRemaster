using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Contacts;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.Application.Contacts.Create;
public record CreateContactCommand : IRequest<TContact>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Language { get; set; }
    public string ProfilPicture { get; set; }

    //public virtual Customer Customer { get; set; } = null!;
    public virtual Address Address { get; set; } = null!;


}

public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, TContact>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateContactCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<TContact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Customers.GetByIdAsync(4)
             ?? throw new EntityNotFoundException(nameof(Customer), 4);

        var contact = new TContact(
                request.FirstName.Trim(),
                request.LastName.Trim(),
                request.Email.Trim(),
                request.PhoneNumber.Trim(),
                request.Language.Trim(),
                request.ProfilPicture.Trim(),
                request.Address,
                user
            );

        _unitOfWork.Contacts.Add(contact);
        await _unitOfWork.SaveChanges();

        return contact;
    }
}   