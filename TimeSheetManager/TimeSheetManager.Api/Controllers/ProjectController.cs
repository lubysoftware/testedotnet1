using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManager.App.Handlers.ProjectNS;
using TimeSheetManager.Domain.Commands;
using TimeSheetManager.Domain.Commands.Project;
using TimeSheetManager.Domain.Entities.Project;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.Api.Controllers {
    [ApiController]
    [Route("v1/Project")]
    public class ProjectController : ControllerBase {
        [HttpGet("{Id}")]
        public async Task<Project> Get([FromRoute] Guid Id, [FromServices] IProjectRepository repository) {  
            return await repository.Get(Id);
        }
        [HttpGet("")]
        public async Task<IEnumerable<Project>> GetAll([FromServices] IProjectRepository repository) {
            return await repository.GetAll();
        }

        [HttpPut("{Id}/{Name}")]
        public async Task<GenericCommandResult> Update([FromRoute] Guid Id, [FromRoute]string Name, [FromServices] UpdateProjectHandler handler) {
            return (GenericCommandResult)await handler.Handle(new UpdateProjectCommand(Id,Name));
        }

        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateProjectCommand command, [FromServices] CreateProjectHandler handler){
            return (GenericCommandResult)await handler.Handle(command);
        }
        [HttpDelete("{Id}")]
        public async Task<GenericCommandResult> Delete([FromRoute] Guid id, [FromServices] DeleteProjectHandler handler){
            return (GenericCommandResult)await handler.Handle(new DeleteProjectCommand(id));
        }
    }
}