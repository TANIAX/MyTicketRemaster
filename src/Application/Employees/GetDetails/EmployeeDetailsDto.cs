
using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.Application.Employees.GetDetails;

public record EmployeeDetailsDto : IMapFrom<Employee>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<TGroup, GroupDetailsDto>();
    }
}
