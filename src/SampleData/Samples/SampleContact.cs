using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Contacts;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.SampleData.Samples;

/// <summary>
/// Returns some contact for testing purposes.
/// </summary>
internal static class SampleContact
{
    internal static List<TContact> GetSample()
    {
        return new List<TContact>()
        {
            new TContact("Mae","Gomez","demond1979@hotmail.com","+32987654321","Français","https://www.fakepersongenerator.com/Face/female/female20161024693503296.jpg",new Address("2 Arboretum Bay", "Talos I", "China", "TAB2"))
        };
    }
}
