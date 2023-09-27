using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Priorities;
using MyTicketRemaster.Domain.Entities.Projects;
using MyTicketRemaster.Domain.Entities.Status;
using MyTicketRemaster.Domain.Entities.Types;
using MyTicketRemaster.Domain.Entities.Users.Contacts;
using MyTicketRemaster.Domain.Entities.Users.Customers;
using MyTicketRemaster.Domain.Entities.Users.Employees;
using MyTicketRemaster.SampleData.Samples;
using MyTicketRemaster.TestData.Samples;
using System.Text.RegularExpressions;

namespace MyTicketRemaster.TestData;

public static class DataGenerator
{
    // <summary>
    // Generates  entities.
    // </summary>
    public static (List<TType>, List<TStatus>, List<Priority>, List<Project>, List<TGroup>,  List<Customer>, List<Employee>, List<TContact>) GenerateBaseEntities()
    {        
        var projects = SampleProjects.GetSample();
        var status = SampleStatus.GetSample();
        var types = SampleTypes.GetSample();
        var priorities = SamplePriorities.GetSample();
        var groups = SampleGroups.GetSample();
        var customers = SampleCustomer.GetSample();
        var employees = SampleEmployee.GetSample();
        var contacts = SampleContact.GetSample();
        return (types, status, priorities, projects, groups, customers, employees, contacts);
    }
}
