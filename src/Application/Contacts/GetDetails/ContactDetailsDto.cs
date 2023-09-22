
using MyTicketRemaster.Application.Common.Mapping;
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

    public Address Address { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDetailsDto>();
    }
}
