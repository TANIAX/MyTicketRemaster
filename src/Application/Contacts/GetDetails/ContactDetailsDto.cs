
using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Application.Contacts.GetList;
using MyTicketRemaster.Application.Customers.GetDetails;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Contacts;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.Application.Contacts.GetDetails;

public record ContactDetailsDto : IMapFrom<TContact>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Language { get; set; }
    public string ProfilPicture { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

    public Address Address { get; set; }
    public CustomerDetailsDto Customer { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TContact, ContactDetailsDto>();
    }
}
