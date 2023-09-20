using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.StoredReplies;

namespace MyTicketRemaster.Application.StoredReplies.GetList;

public record StoredReplyDto : IMapFrom<StoredReply>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public bool Editable { get; set; } 

    public void Mapping(Profile profile)
    {
        profile.CreateMap<StoredReply, StoredReplyDto>();
    }
}