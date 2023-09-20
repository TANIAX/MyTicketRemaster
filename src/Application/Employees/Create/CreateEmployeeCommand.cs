using MyTicketRemaster.Application.Common.Dependencies.DataAccess;
using MyTicketRemaster.Domain.Entities.Users.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Employees.Create;
public record CreateEmployeeCommand : IRequest<Employee>
{
}

public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}   