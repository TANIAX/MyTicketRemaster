using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.GetDetails;

public record TypeDetailsDto : IMapFrom<TType>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public DateTime? LastModifiedAt { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TType, TypeDetailsDto>();
    }
}