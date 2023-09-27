using MyTicketRemaster.Domain.Entities.Projects;

namespace MyTicketRemaster.SampleData.Samples;

/// <summary>
/// Returns some projects for testing purposes.
/// </summary>
internal static class SampleProjects
{
    internal static List<Project> GetSample()
    {
        return new List<Project>()
        {
            new Project("Inconnu",false),
            new Project("Logistique",true),
            new Project("Finance",true),
            new Project("Prestation",true),
            new Project("Organizer",true),
        };
    }
}