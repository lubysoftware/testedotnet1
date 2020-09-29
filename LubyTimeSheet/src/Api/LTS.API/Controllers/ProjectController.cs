using LTS.Domain.Base;
using LTS.Domain.Commands;
using LTS.Domain.Commands.Project;
using LTS.Domain.Handlers;
using LTS.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace LTS.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/project")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [Route("projectId:guid")]
        public async Task<GenericCommandResult> GetById(Guid projectId)
        {
            return await _projectService.GetById(projectId);
        }

        [HttpGet]
        public async Task<GenericCommandResult> GetAllPaginated([FromQuery] PaginationParameters paginationParameters)
        {
            return await _projectService.GetAllPaginated(paginationParameters);
        }


        [HttpPost]
        [Route("developer")]
        public async Task<GenericCommandResult> AddDeveloperInProject([FromBody] AddDeveloperInProjectCommand command, [FromServices] ProjectHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpDelete]
        [Route("developer")]
        public async Task<GenericCommandResult> RemoveDeveloperFromProject([FromBody] RemoveDeveloperFromProjectCommand command, [FromServices] ProjectHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpPut]
        public async Task<GenericCommandResult> Update([FromBody] UpdateProjectCommand command, [FromServices] ProjectHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateProjectCommand command, [FromServices] ProjectHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpDelete]

        public async Task<GenericCommandResult> Delete([FromBody] DeleteProjectCommand command, [FromServices] ProjectHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

    }
}
