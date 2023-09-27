using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Groups.GetList;
using MyTicketRemaster.Application.Status.Delete;
using MyTicketRemaster.Application.Status.Create;
using MyTicketRemaster.Application.Statuss.GetStatusDetails;
using MyTicketRemaster.Application.Statuss.GetStatusGetStatusList;
using MyTicketRemaster.Application.Statuss.UpdatStatus;
using MyTicketRemaster.Domain.Entities.Status;

namespace MyTicketRemaster.WebApi.API.V1;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("v{v:apiVersion}/status")]
public class StatusController : ControllerBase
{
    private readonly IMediator _mediator;

    public StatusController(IMediator mediator)
        => _mediator = mediator;


    //GET api/v1/status - List
    [HttpGet]
    [Description("List status")]
    public async Task<ActionResult<IListResponseModel<TStatus>>> GetList([FromQuery] ListQueryModel<StatusDto> query)
        => Ok(await _mediator.Send(query));


    //GET api/v1/status/5 - Print
    [HttpGet("{id}")]
    [Description("print a status")]
    public async Task<ActionResult<StatusDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetStatusDetailsQuery(id)));


    //POST api/v1/status - Create
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Description("Create a status")]
    public async Task<ActionResult<TStatus>> Post(CreateStatusCommand command)
        => Ok(await _mediator.Send(command));


    //PUT api/v1/status - Update
    [HttpPut]
    [Authorize(Roles = "Admin")]
    [Description("Update a status")]
    public async Task<ActionResult<TStatus>> Put(UpdateStatusCommand command)
       => Ok(await _mediator.Send(command));


    //DELETE api/v1/status/5 - Delete
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [Description("Delete a status")]
    public async Task<ActionResult<Unit>> Delete(int id)
       => Ok(await _mediator.Send(new DeleteStatusCommand(id)));
}

