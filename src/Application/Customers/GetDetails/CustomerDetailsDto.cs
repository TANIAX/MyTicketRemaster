
using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.Application.Customers.GetDetails;

public record CustomerDetailsDto : IMapFrom<Customer>
{
    public int Id { get; set; }
    public string CompanyName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Signature { get; private set; }
    public string Language { get; private set; }
    public string? ProfilPicture { get; private set; }
    public Address Address { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }
    public void Mapping(Profile profile)
    {

        profile.CreateMap<Customer, CustomerDetailsDto>();
    }
}
