
using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.Application.Customers.GetDetails;

public record CustomerDetailsDto : IMapFrom<Customer>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDetailsDto>();
    }
}
