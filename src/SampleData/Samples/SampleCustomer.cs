using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Customers;

namespace MyTicketRemaster.SampleData.Samples;

/// <summary>
/// Returns some customer for testing purposes.
/// </summary>
internal static class SampleCustomer
{
    internal static List<Customer> GetSample()
    {
        return new List<Customer>()
        {
            new Customer("My company", "Customer123@my-ticket-remaster.be","+32456789012","no sign required, just a stamp","Français","","https://www.fakepersongenerator.com/Face/male/male20171084029745300.jpg", new Address("1 Weyland Way", "Tokyo", "Japan", "100-6007"))
        };
    }
}