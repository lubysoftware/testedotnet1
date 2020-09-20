using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using TimeManager.Application.Projects;
using TimeManager.Application.Projects.CancelProject;
using TimeManager.Application.Projects.ChangeProjectDetails;
using TimeManager.Application.Projects.GetProjects;
using TimeManager.Application.Projects.RegisterProject;

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
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetProjectsQuery());

            return Ok(result);
        }

        /// <summary>
        /// Register a new project.
        /// </summary>
        /// <param name="request">Name of the project</param>
        [HttpPost]
        [ProducesResponseType(typeof(ProjectDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterProject([FromBody] ProjectDetailsRequest request)
        {
            var response = await _mediator.Send(new RegisterProjectCommand(request.Name));

            if (response.IsSuccess)
                return BadRequest(response.Errors);

            return Created(string.Empty, null);
            
        }

        /// <summary>
        /// Update project details.
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="request">Name of the project</param>
        [HttpPut("{projectId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeProjectDetails([FromRoute] Guid projectId, [FromBody] ProjectDetailsRequest request)
        {
            var response = await _mediator.Send(new ChangeProjectDetailsCommand(projectId, request.Name));

            if (response.IsSuccess)
                return BadRequest(response.Errors);

            return Ok();
        }

        /// <summary>
        /// Cancel a project.
        /// </summary>
        /// <param name="projectId">Project ID</param>
        [HttpDelete("{projectId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CancelProject([FromRoute] Guid projectId)
        {
            var response = await _mediator.Send(new CancelProjectCommand(projectId));

            if (response.IsSuccess)
                return BadRequest(response.Errors);

            return Ok();
        }
    }
}
