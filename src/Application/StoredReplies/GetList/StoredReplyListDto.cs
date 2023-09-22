using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.GetList;

public record StoredReplyDto : IMapFrom<StoredReply>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Reply { get; set; } 

    public void Mapping(Profile profile)
    {
        profile.CreateMap<StoredReply, StoredReplyDto>();
    }
}