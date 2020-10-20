using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManager.App.Handlers.DeveloperNS;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.DeveloperNS;
using TimeSheetManager.Domain.Entities.DeveloperNS;
using TimeSheetManager.Domain.Repositories;

namespace TimeSheetManager.Api.Controllers {
    [ApiController]
    [Route("v1/developer")]
    public class DeveloperController : ControllerBase {
        [HttpGet("{Id}")]
        public async Task<Developer> Get([FromRoute] Guid Id, [FromServices] IDeveloperRepository repository) {  
            return await repository.Get(Id);
        }
        [HttpGet("")]
        public async Task<IEnumerable<Developer>> GetAll([FromServices] IDeveloperRepository repository) {
            return await repository.GetAll();
        }

        [HttpPut("{Id}/{Name}")]
        public async Task<GenericCommandResult> Update([FromRoute] Guid Id, [FromRoute]string Name, [FromServices] UpdateDeveloperHandler handler) {
            return (GenericCommandResult)await handler.Handle(new UpdateDeveloperCommand(Id,Name));
        }

        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateDeveloperCommand command, [FromServices] CreateDeveloperHandler handler){
            return (GenericCommandResult)await handler.Handle(command);
        }
        [HttpDelete("{Id}")]
        public async Task<GenericCommandResult> Delete([FromRoute] Guid id, [FromServices] DeleteDeveloperHandler handler){
            return (GenericCommandResult)await handler.Handle(new DeleteDeveloperCommand(id));
        }
    }
}