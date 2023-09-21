
using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Application.Contacts.GetDetails;

public record ContactDetailsDto : IMapFrom<TContact>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDetailsDto>();
    }
}
