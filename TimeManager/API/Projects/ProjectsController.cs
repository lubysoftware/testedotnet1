using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TimeManager.Application.Projects;
using TimeManager.Application.Projects.Commands.Create;
using TimeManager.Application.Projects.Commands.Delete;
using TimeManager.Application.Projects.Commands.Update;
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
        /// Get all projects.
        /// </summary>
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
        /// Register a new project.
        /// </summary>
        /// <param name="request">Name of the project</param>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterProject([FromBody] ProjectRequest request)
        {
            await _mediator.Send(new CreateProjectCommand(request.Name));

            return Created(string.Empty, null);
        }

        /// <summary>
        /// Update project.
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="request">Name of the project</param>
        [HttpPut("{projectId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProject([FromRoute] Guid projectId, [FromBody] ProjectRequest request)
        {
            await _mediator.Send(new UpdateProjectCommand(projectId, request.Name));

            return Ok();
        }

        /// <summary>
        /// Delete a project.
        /// </summary>
        /// <param name="projectId">Project ID</param>
        [HttpDelete("{projectId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProject([FromRoute] Guid projectId)
        {
            await _mediator.Send(new DeleteProjectCommand(projectId));

            return Ok();
        }
    }
}
