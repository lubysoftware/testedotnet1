using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using TimeManager.Application.Projects.Commands.Create;
using TimeManager.Application.Projects.Queries;

namespace API.Projects
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(ProjectsViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetProjects()
        {
            var result = await _mediator.Send(new GetProjectsQuery());

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Register a new project
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterProject([FromBody]CreateProjectCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
