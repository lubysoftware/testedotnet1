using System;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.Commands.Create;
using LubyClocker.Application.BoundedContexts.Developers.Commands.Delete;
using LubyClocker.Application.BoundedContexts.Developers.Commands.Update;
using LubyClocker.Application.BoundedContexts.Developers.Queries.FindAll;
using LubyClocker.Application.BoundedContexts.Developers.Queries.FindById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubyClocker.Api.Controllers
{
    [Route("api/v1/developers")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class DevelopersController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDeveloperCommand command)
        {
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(Add), result);
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Edit([FromBody] UpdateDeveloperCommand command, [FromRoute] Guid id)
        {
            var result = await _mediator.Send(command.IncludeId(id));
            
            return Ok(result);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new  DeleteDeveloperCommand().IncludeId(id));
            
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] FindDevelopersQuery query)
        {
            var result = await _mediator.Send(query);
            
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> FindById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindDeveloperByIdQuery().IncludeId(id));
            
            return Ok(result);
        }
    }
}
