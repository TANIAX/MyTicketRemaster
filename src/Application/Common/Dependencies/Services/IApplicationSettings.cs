namespace MyTicketRemaster.Application.Dependencies.Services;

public interface IApplicationSettings
{
    int defautPriorityId { get; }
    int defautStatusId { get; }
    int defautTypeId { get; }
    int defautProjectId { get; }
}
