using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.SampleData.Samples;

/// <summary>
/// Returns some employee for testing purposes.
/// </summary>
internal static class SampleEmployee
{
    internal static List<Employee> GetSample()
    {
        return new List<Employee>()
        {
            new Employee("Dustin","Neveu","Employee123@my-ticket-remaster.be","+32123456789","My sign","Français","https://www.fakepersongenerator.com/Face/male/male1084698250305.jpg")
        };
    }
}
