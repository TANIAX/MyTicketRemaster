using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Application.Common.Exceptions;
using MyTicketRemaster.Application.Contacts.Create;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Contacts;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.Application.Contacts.Update;

public record UpdateContactCommand : IRequest<TContact>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Language { get; set; }
    public string ProfilPicture { get; set; }

    public int CustomerId { get; set; }
    public virtual Address Address { get; set; }
}
public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, TContact>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateContactCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<TContact> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.Contacts.GetByIdAsync(request.Id)
                 ?? throw new EntityNotFoundException(nameof(TContact), request.Id);

        var customer = await _unitOfWork.Customers.GetByIdAsync(request.CustomerId)
                 ?? throw new EntityNotFoundException(nameof(Customer), request.CustomerId);

        contact.UpdateFirstName(request.FirstName.Trim());
        contact.UpdateLastName(request.LastName.Trim());
        contact.UpdateEmail(request.Email.Trim());
        contact.UpdatePhoneNumber(request.PhoneNumber.Trim());
        contact.UpdateLanguage(request.Language.Trim());
        contact.UpdateProfilPicture(request.ProfilPicture.Trim());
        contact.UpdateAddress(request.Address);
        contact.UpdateCustomer(customer);

        await _unitOfWork.SaveChanges();

        return contact;
    }

}
