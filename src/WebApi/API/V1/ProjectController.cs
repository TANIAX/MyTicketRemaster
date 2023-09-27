using Microsoft.AspNetCore.Mvc;
using MyTicketRemaster.Application.Common.Dependencies.DataAccess.Repositories.Common;
using MyTicketRemaster.Application.Contacts.Update;
using MyTicketRemaster.Application.Groups.GetDetails;
using MyTicketRemaster.Application.Projects.Create;
using MyTicketRemaster.Application.Projects.Delete;
using MyTicketRemaster.Application.Projects.GetDetails;
using MyTicketRemaster.Application.Projects.GetList;
using MyTicketRemaster.Application.Projects.Update;
using MyTicketRemaster.Domain.Entities.Projects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyTicketRemaster.WebApi.API.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [Route("v{v:apiVersion}/project")]
    public class ProjectController : ControllerBase
    {
        private IMediator _mediator;

        public ProjectController(IMediator mediator)
            => _mediator = mediator;


        // GET api/v1/project
        [HttpGet]
        [Description("List projects")]
        public async Task<ActionResult<IListResponseModel<Project>>> Get([FromQuery] ListQueryModel<ProjectDto> query)
            => Ok(await _mediator.Send(query));

        // GET api/v1/project/1
        [HttpGet("{id}")]
        [Description("Print a project")]
        public async Task<ActionResult<ProjectDetailsDto>> Get(int id)
            => Ok(await _mediator.Send(new GetProjectDetailsQuery(id)));

        // POST api/projet
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Description("Create a project")]
        public async Task<ActionResult<Project>> Post(CreateProjectCommand command)
            => Ok(await _mediator.Send(command));

        // PUT api/projet
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Description("Update a project")]
        public async Task<ActionResult<Project>> Put(UpdateProjectCommand command)
            => Ok(await _mediator.Send(command));

        // DELETE api/projet/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [Description("Delete a project")]
        public async Task<ActionResult<Unit>> Delete(int id)
            => Ok(await _mediator.Send(new DeleteProjectCommand(id)));
    }
}
