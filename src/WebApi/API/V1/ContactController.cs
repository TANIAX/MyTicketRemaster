using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Contacts.Create;
using MyTicketRemaster.Application.Contacts.Delete;
using MyTicketRemaster.Application.Contacts.GetDetails;
using MyTicketRemaster.Application.Contacts.GetList;
using MyTicketRemaster.Application.Contacts.Update;
using MyTicketRemaster.Application.Groups.GetList;
using MyTicketRemaster.Domain.Entities.Users.Contacts;

namespace MyTicketRemaster.WebApi.API.V1;

[ApiController]
[ApiVersion("1.0")]
[Authorize]
[Route("v{v:apiVersion}/contact")]
public class ContactController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContactController(IMediator mediator)
        => _mediator = mediator;

    // GET api/v1/contact - List
    [HttpGet]
    [Description("List contacts")]
    public async Task<ActionResult<IListResponseModel<ContactDto>>> GetList([FromQuery] ListQueryModel<ContactDto> query)
    => Ok(await _mediator.Send(query));

    // GET api/v1/contact/5 - Print
    [HttpGet("{id}")]
    [Description("print a contact")]
    public async Task<ActionResult<ContactDetailsDto>> Get(int id)
        => Ok(await _mediator.Send(new GetContactDetailsQuery(id)));

    // POST api/v1/contact - Create
    [HttpPost]
    [Description("Create a contact")]
    public async Task<ActionResult<TContact>> Create(CreateContactCommand command)
        => Ok(await _mediator.Send(command));

    // PUT api/v1/contact - Update
    [HttpPut]
    [Description("Update a contact")]
    public async Task<ActionResult<TContact>> Update(UpdateContactCommand command)
        => Ok(await _mediator.Send(command));

    // DELETE api/v1/contact/5 - Delete
    [HttpDelete("{id}")]
    [Description("Delete a contact")]
    public async Task<ActionResult<Unit>> Delete(int id)
        => Ok(await _mediator.Send(new DeleteContactCommand(id)));
}
