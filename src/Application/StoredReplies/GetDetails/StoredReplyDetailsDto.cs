using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.StoredReplies.GetDetails;

public record StoredReplyDetailsDto : IMapFrom<Project>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public bool Editable { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime? LastModifiedAt { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, StoredReplyDetailsDto>();
    }
}