using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Projects;
using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.GetDetails;

public record StoredReplyDetailsDto : IMapFrom<StoredReply>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Reply { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<StoredReply, StoredReplyDetailsDto>();
    }
}