using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.GetList;

public record TypeDto : IMapFrom<TType>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TType, TypeDto>();
    }
}