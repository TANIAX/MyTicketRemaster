using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.GetGroupGetGroupList;

public record GroupDto : IMapFrom<TGroup>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDto>();
    }
}