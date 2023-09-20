using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.Application.Statuss.GetStatusGetStatusList;

public record StatusDto : IMapFrom<TStatus>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TStatus, StatusDto>();
    }
}