using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Types.Create;
using MyTicketRemaster.Application.Types.Delete;
using MyTicketRemaster.Application.Types.GetList;
using MyTicketRemaster.Application.Types.Update;
using MyTicketRemaster.Application.Types.GetDetails;
using MyTicketRemaster.Domain.Entities.Types;
using MyTicketRemaster.Application.Type.GetDetails;

namespace MyTicketRemaster.WebApi.API.V1;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("v{v:apiVersion}/Type")]
public class TypeController : ControllerBase
{
    private readonly IMediator _mediator;

    public TypeController(IMediator mediator)
     => _mediator = mediator;

    //GET api/v1/type - List
    [HttpGet]
    [Description("List types")]
    public async Task<ActionResult<IListResponseModel<TType>>> GetList([FromQuery] ListQueryModel<TypeDto> query)
        => Ok(await _mediator.Send(query));

    //GET api/v1/type/5 - Print
    [HttpGet("{id}")]
    [Description("print a type")]
    public async Task<ActionResult<TypeDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetTypeDetailsQuery(id)));

    //POST api/v1/type - Create
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Description("Create a type")]
    public async Task<ActionResult<TType>> Create(CreateTypeCommand command)
        => Ok(await _mediator.Send(command));


    //PUT api/v1/type - Update
    [HttpPut]
    [Authorize(Roles = "Admin")]
    [Description("Update a type")]
    public async Task<ActionResult<TType>> Update(UpdateTypeCommand command)
        => Ok(await _mediator.Send(command));

    //DELETE api/v1/type/5 - Delete
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    [Description("Delete a type")]
    public async Task<ActionResult<Unit>> Delete(int id)
        => Ok(await _mediator.Send(new DeleteTypeCommand(id)));

}
