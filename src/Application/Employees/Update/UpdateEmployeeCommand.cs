using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Users.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Employees.Update;

public record UpdateEmployeeCommand : IRequest<Employee>
{

}
public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
