using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.SampleData.Samples;

/// <summary>
/// Returns some groups for testing purposes.
/// </summary>
internal static class SampleGroups
{
    internal static List<TGroup> GetSample()
    {
        return new List<TGroup>()
        {
            new TGroup("Inconnu"),
            new TGroup("Software"),
            new TGroup("Hardware"),
            new TGroup("Comptabilité"),
        };
    }
}