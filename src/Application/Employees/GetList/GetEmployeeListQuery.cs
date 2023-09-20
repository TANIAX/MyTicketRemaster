using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Employees.GetList;

public record GetEmployeeListQuery : IRequest<List<EmployeeDto>>
{

}

public class GetEmployeeListQueryHandler : IRequestHandler<GetEmployeeListQuery, List<EmployeeDto>>
{
    public Task<List<EmployeeDto>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}