using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Groups.Create;
using MyTicketRemaster.Application.Groups.Delete;
using MyTicketRemaster.Application.Groups.GetList;
using MyTicketRemaster.Application.Groups.Update;
using MyTicketRemaster.Application.Groups.GetDetails;
using GetGroupDetailsQuery = MyTicketRemaster.Application.Groups.GetDetails.GetGroupDetailsQuery;
using MyTicketRemaster.Domain.Entities.Groups;

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

    // GET api/v1/group - List 
    [HttpGet]
    [Description("List groups")]
    public async Task<ActionResult<IListResponseModel<GroupDto>>> GetList([FromQuery] ListQueryModel<GroupDto> query)
        => Ok(await _mediator.Send(query));

    // GET api/v1/group/5 - Print
    [HttpGet("{id}")]
    [Description("print a group")]
    public async Task<ActionResult<GroupDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetGroupDetailsQuery(id)));

    //POST api/v1/group - Create
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Description("Create a group")]
    public async Task<ActionResult<TGroup>> Create(CreateGroupCommand command)
        => Ok(await _mediator.Send(command));

    //PUT api/v1/group - Update
    [HttpPut]
    [Authorize(Roles = "Admin")]
    [Description("Update a group")]
    public async Task<ActionResult<TGroup>> Update(UpdateGroupCommand command)
        => Ok(await _mediator.Send(command));

    //DELETE api/v1/group/5 - Delete
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [Description("Delete a group")]
    public async Task<ActionResult<Unit>> Delete(int id)
        => Ok(await _mediator.Send(new DeleteGroupCommand(id)));

}
