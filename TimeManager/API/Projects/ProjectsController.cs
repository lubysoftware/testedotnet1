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
using API.Projects.ProjectMembers;
using TimeManager.Application.Projects.RegisterMember;

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
        public async Task<IActionResult> RegisterProject([FromBody] ProjectDetailsRequest request)
        {
            await _mediator.Send(new RegisterProjectCommand(request.Name));

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
            await _mediator.Send(new ChangeProjectDetailsCommand(projectId, request.Name));

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
            await _mediator.Send(new CancelProjectCommand(projectId));

            return Ok();
        }

        /// <summary>
        /// Register a new member to a project.
        /// </summary>
        /// <param name="projectId">Project ID</param>
        /// <param name="request">Developer Id</param>
        /// <returns></returns>
        [HttpPost("{projectId}/members")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RegisterProjectMember([FromRoute] Guid projectId, [FromBody] RegisterProjectMemberRequest request)
        {
            await _mediator.Send(new RegisterProjectMemberCommand(request.DeveloperId, projectId));

            return Ok();
        }
    }
}
