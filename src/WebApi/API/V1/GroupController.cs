using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Groups.Create;
using MyTicketRemaster.Application.Groups.Delete;
using MyTicketRemaster.Application.Groups.GetList;
using MyTicketRemaster.Application.Groups.Update;
using MyTicketRemaster.Application.Groups.GetDetails;
using GetGroupDetailsQuery = MyTicketRemaster.Application.Groups.GetDetails.GetGroupDetailsQuery;

namespace MyTicketRemaster.WebApi.API.V1;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("v{v:apiVersion}/group")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupController(IMediator mediator)
     => _mediator = mediator;


    //Get
    [HttpGet("{id}")]
    public async Task<ActionResult<GroupDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetGroupDetailsQuery(id)));

    //List
    [HttpGet]
    public async Task<ActionResult<IListResponseModel<GroupDto>>> GetList([FromQuery] ListQueryModel<GroupDto> query)
        => Ok(await _mediator.Send(query));

    //Create
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateGroupCommand command)
        => Ok(await _mediator.Send(command));

    //Update
    [HttpPut("{id}")]
    public async Task<ActionResult<int>> Update(UpdateGroupCommand command)
        => Ok(await _mediator.Send(command));

    //Delete
    [HttpDelete("{id}")]
    public async Task<ActionResult<int>> Delete(int id)
        => Ok(await _mediator.Send(new DeleteGroupCommand(id)));

}
