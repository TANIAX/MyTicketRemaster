using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Priorities;

namespace MyTicketRemaster.Application.Priorities.GetList;

public record PriorityDto : IMapFrom<Priority>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public bool Editable { get; set; } 

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Priority, PriorityDto>();
    }
}