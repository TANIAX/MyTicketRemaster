using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Application.Priorities.Create;
using MyTicketRemaster.Application.Priorities.Delete;
using MyTicketRemaster.Application.Priorities.GetDetails;
using MyTicketRemaster.Application.Priorities.GetList;
using MyTicketRemaster.Application.Priorities.Update;
using MyTicketRemaster.Domain.Entities.Priorities;
using GetPriorityDetailsQuery = MyTicketRemaster.Application.Priorities.GetDetails.GetPriorityDetailsQuery;

namespace MyTicketRemaster.WebApi.API.V1;


[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("v{v:apiVersion}/priority")]
public class PriorityController : ControllerBase
{
    private readonly IMediator _mediator;

    public PriorityController(IMediator mediator)
     => _mediator = mediator;

    //GET api/v1/priority - List
    [HttpGet]
    [Description("List priorities")]
    public async Task<ActionResult<IListResponseModel<Priority>>> GetList([FromQuery] ListQueryModel<PriorityDto> query)
        => Ok(await _mediator.Send(query));

    //GET api/v1/priority/5 - Print
    [HttpGet("{id}")]
    [Description("print a priority")]
    public async Task<ActionResult<PriorityDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetPriorityDetailsQuery(id)));

    //POST api/v1/priority - Create
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Description("Create a priority")]
    public async Task<ActionResult<Priority>> Create(CreatePriorityCommand command)
        => Ok(await _mediator.Send(command));

    //PUT api/v1/priority - Update
    [HttpPut]
    [Authorize(Roles = "Admin")]
    [Description("Update a priority")]
    public async Task<ActionResult<Priority>> Update(UpdatePriorityCommand command)
        => Ok(await _mediator.Send(command));

    //DELETE api/v1/priority/5 - Delete
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [Description("Delete a priority")]
    public async Task<ActionResult<Unit>> Delete(int id)
        => Ok(await _mediator.Send(new DeletePriorityCommand(id)));
}

