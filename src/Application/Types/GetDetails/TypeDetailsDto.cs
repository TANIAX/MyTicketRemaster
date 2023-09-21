using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.GetDetails;

public record TypeDetailsDto : IMapFrom<TType>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? LastModifiedAt { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TType, TypeDetailsDto>();
    }
}