using MyTicketRemaster.Domain.Entities.Types;

namespace MyTicketRemaster.TestData.Samples;

/// <summary>
/// Returns some types for testing purposes.
/// </summary>
internal static class SampleTypes
{
    internal static List<TType> GetSample()
    {
        return new List<TType>()
        {
            new TType("Inconnu",false),
            new TType("Demande de fonctionnalité",true),
            new TType("Problème",true),
            new TType("Question",true),
        };
    }
}