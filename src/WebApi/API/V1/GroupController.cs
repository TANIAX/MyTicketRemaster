using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Groups.Commands.Delete;
using MyTicketRemaster.Application.Groups.Commands.Update;
using MyTicketRemaster.Application.Groups.CreateGroup;
using MyTicketRemaster.Application.Groups.GetGroupDetails;
using MyTicketRemaster.Application.Groups.GetGroupGetGroupList;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
