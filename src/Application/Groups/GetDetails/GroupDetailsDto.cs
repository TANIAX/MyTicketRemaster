using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Groups;

namespace MyTicketRemaster.Application.Groups.GetDetails;

public record GroupDetailsDto : IMapFrom<TGroup>
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDetailsDto>();
    }
}