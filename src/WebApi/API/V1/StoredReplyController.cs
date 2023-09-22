using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Application.Statuss.GetStatusGetStatusList;
using MyTicketRemaster.Application.StoredReplies.Create;
using MyTicketRemaster.Application.StoredReplies.Delete;
using MyTicketRemaster.Application.StoredReplies.GetDetails;
using MyTicketRemaster.Application.StoredReplies.GetList;
using MyTicketRemaster.Application.StoredReplies.Update;
using MyTicketRemaster.Domain.Entities.Status;
using MyTicketRemaster.Domain.Entities.StoredReplies;
using GetStoredReplyDetailsQuery = MyTicketRemaster.Application.StoredReplies.GetDetails.GetStoredReplyDetailsQuery;

namespace MyTicketRemaster.WebApi.API.V1;


[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("v{v:apiVersion}/StoredReply")]
public class StoredReplyController : ControllerBase
{
    private readonly IMediator _mediator;

    public StoredReplyController(IMediator mediator)
     => _mediator = mediator;
    
    //List
    [HttpGet]
    [Description("List StoredReplies")]
    public async Task<ActionResult<IListResponseModel<StoredReply>>> GetList([FromQuery] ListQueryModel<StoredReplyDto> query)
        => Ok(await _mediator.Send(query));

    //Get
    [HttpGet("{id}")]
    [Description("print a StoredReply")]
    public async Task<ActionResult<StoredReplyDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetStoredReplyDetailsQuery(id)));

    //Create
    [HttpPost]
    [Description("Create a StoredReply")]
    public async Task<ActionResult<StoredReply>> Create(CreateStoredReplyCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut]
    [Description("Update a StoredReply")]
    public async Task<ActionResult<StoredReply>> Update(UpdateStoredReplyCommand command)
        => Ok(await _mediator.Send(command));

    [HttpDelete("{id}")]
    [Description("Delete a StoredReply")]
    public async Task<ActionResult<Unit>> Delete(int id)
        => Ok(await _mediator.Send(new DeleteStoredReplyCommand(id)));
}

