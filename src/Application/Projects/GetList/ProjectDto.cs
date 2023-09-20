using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.Application.Projects.GetList;

public record ProjectDto : IMapFrom<Project>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public bool Editable { get; set; } 

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Project, ProjectDto>();
    }
}