using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.Application.Types.GetList;

public record TypeDto : IMapFrom<TType>
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TType, TypeDto>();
    }
}