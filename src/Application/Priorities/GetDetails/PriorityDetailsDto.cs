using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.Priorities.GetDetails;

public record PriorityDetailsDto : IMapFrom<Project>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Editable { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, PriorityDetailsDto>();
    }
}