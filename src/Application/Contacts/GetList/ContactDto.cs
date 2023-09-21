using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.Application.Contacts.GetList;

public record ContactDto : IMapFrom<TContact>
{

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TContact, ContactDto>();
    }
}

