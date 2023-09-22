using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Contacts.Create;
using MyTicketRemaster.Application.Contacts.Delete;
using MyTicketRemaster.Application.Contacts.GetDetails;
using MyTicketRemaster.Application.Contacts.GetList;
using MyTicketRemaster.Application.Contacts.Update;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.WebApi.API.V1;

[ApiController]
[ApiVersion("1.0")]
//[Authorize]
[Route("v{v:apiVersion}/contact")]
public class ContactController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    [Description("List contacts")]
    public async Task<ActionResult<IListResponseModel<TContact>>> GetList([FromQuery] ListQueryModel<ContactDto> query)
        => Ok(await _mediator.Send(query));

    [HttpGet("{id}")]
    [Description("print a contact")]
    public async Task<ActionResult<ContactDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetContactDetailsQuery(id)));

    [HttpPost]
    [Description("Create a contact")]
    public async Task<ActionResult<TContact>> Create(CreateContactCommand command)
        => Ok(await _mediator.Send(command));

    [HttpPut]
    [Description("Update a contact")]
    public async Task<ActionResult<TContact>> Update(UpdateContactCommand command)
        => Ok(await _mediator.Send(command));

    [HttpDelete("{id}")]
    [Description("Delete a contact")]
    public async Task<ActionResult<Unit>> Delete(int id)
        => Ok(await _mediator.Send(new DeleteContactCommand(id)));
}
