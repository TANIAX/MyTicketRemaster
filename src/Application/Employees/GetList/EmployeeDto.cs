using MyTicketRemaster.Application.Common.Mapping;
using MyTicketRemaster.Domain.Entities.Users.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Employees.GetList;

public record EmployeeDto : IMapFrom<Employee>
{

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Employee, EmployeeDto>();
    }
}

