using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTicketRemaster.Application.Employees.Delete;

public record DeleteEmployeeCommand : IRequest<Unit>
{

}

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
{
    public Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

