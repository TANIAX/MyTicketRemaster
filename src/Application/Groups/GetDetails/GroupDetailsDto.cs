using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.GetDetails;

public record GroupDetailsDto : IMapFrom<TGroup>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public DateTime? LastModifiedAt { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDetailsDto>();
    }
}