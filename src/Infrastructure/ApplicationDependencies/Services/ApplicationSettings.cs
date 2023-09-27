using Microsoft.Extensions.Configuration;

namespace MyTicketRemaster.Application.Dependencies.Services;

public class ApplicationSettings : IApplicationSettings
{
    public int defautPriorityId { get; set; }
    public int defautStatusId { get; set; }
    public int defautTypeId { get; set; }
    public int defautProjectId { get; set; }

    public ApplicationSettings(IConfiguration configuration)
    {
        //Tickets.DefaultId.Priority
        string prefix = "Tickets.DefaultId.";

        defautPriorityId = configuration.GetValue<int>($"{prefix}Priority");
        defautStatusId = configuration.GetValue<int>($"{prefix}Status");
        defautTypeId = configuration.GetValue<int>($"{prefix}Type");
        defautProjectId = configuration.GetValue<int>($"{prefix}Project");
    }
}
