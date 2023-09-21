using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.Application.Statuss.GetStatusDetails;

public record StatusDetailsDto : IMapFrom<TStatus>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TStatus, StatusDetailsDto>();
    }
}