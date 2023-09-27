using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.TestData.Samples;

/// <summary>
/// Returns some status for testing purposes.
/// </summary>
internal static class SampleStatus
{
    internal static List<TStatus> GetSample()
    {
        return new List<TStatus>()
        {
            new TStatus("Clos",false),
            new TStatus("Ouvert",false),
            new TStatus("En attente d'un tier",true),
            new TStatus("En attente du client",true),
        };
    }
}