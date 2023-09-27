using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Application.Customers.GetList;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Contacts;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.Application.Contacts.GetList;

public record ContactDto : IMapFrom<TContact>
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
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TContact, ContactDto>()
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.Customer.Id));
    }
}

