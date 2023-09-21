using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Types.Create;
using MyTicketRemaster.Application.Types.Delete;
using MyTicketRemaster.Application.Types.GetList;
using MyTicketRemaster.Application.Types.Update;
using MyTicketRemaster.Application.Types.GetDetails;
using MyTicketRemaster.Domain.Entities.Types;

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

    [HttpGet]
    [Description("List types")]
    public async Task<ActionResult<IListResponseModel<TType>>> GetList([FromQuery] ListQueryModel<TypeDto> query)
        => Ok(await _mediator.Send(query));

    //Get
    [HttpGet("{id}")]
    [Description("print a type")]
    public async Task<ActionResult<TypeDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetTypeDetailsQuery(id)));

    //Create
    [HttpPost]
    [Description("Create a type")]
    public async Task<ActionResult<TType>> Create(CreateTypeCommand command)
        => Ok(await _mediator.Send(command));


    //Update
    [HttpPut]
    [Description("Update a type")]
    public async Task<ActionResult<TType>> Update(UpdateTypeCommand command)
        => Ok(await _mediator.Send(command));

    //Delete
    [HttpDelete("{id}")]
    [Description("Delete a type")]
    public async Task<ActionResult<Unit>> Delete(int id)
        => Ok(await _mediator.Send(new DeleteTypeCommand(id)));

}
