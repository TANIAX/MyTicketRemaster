using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.GetList;

public record GroupDto : IMapFrom<TGroup>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDto>();
    }
}