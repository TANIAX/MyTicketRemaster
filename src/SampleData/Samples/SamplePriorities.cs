using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Priorities;
using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.SampleData.Samples;

/// <summary>
/// Returns some priorities for testing purposes.
/// </summary>
internal static class SamplePriorities
{
    internal static List<Priority> GetSample()
    {
        return new List<Priority>()
        {
            new Priority("Inconnu",false),
            new Priority("Faible",true),
            new Priority("Moyen",true),
            new Priority("Haut",true),
            new Priority("Urgent",true),
        };
    }
}