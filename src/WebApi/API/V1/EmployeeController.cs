using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Employees.Create;
using MyTicketRemaster.Domain.Entities.Groups;
using MyTicketRemaster.Domain.Entities.Users.Employees;

namespace MyTicketRemaster.WebApi.API.V1;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("v{v:apiVersion}/employee")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeController(IMediator mediator)
     => _mediator = mediator;

   
    //POST api/v1/employee - Create
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Description("Create a employee")]
    public async Task<ActionResult<Employee>> Create(CreateEmployeeCommand command)
        => Ok(await _mediator.Send(command));

}
