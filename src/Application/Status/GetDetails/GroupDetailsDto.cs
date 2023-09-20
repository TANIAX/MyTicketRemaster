using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Status;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.Application.Statuss.GetStatusDetails;

public record StatusDetailsDto : IMapFrom<TStatus>
{
    public int Id { get; init; }
    public string Name { get; init; } = null!;
    public DateTime CreatedAt { get; init; }
    public DateTime? LastModifiedAt { get; init; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<TStatus, StatusDetailsDto>();
    }
}