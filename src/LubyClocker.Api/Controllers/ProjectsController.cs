using System;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.Commands.AddMember;
using LubyClocker.Application.BoundedContexts.Projects.Commands.Create;
using LubyClocker.Application.BoundedContexts.Projects.Commands.CreateTimeEntry;
using LubyClocker.Application.BoundedContexts.Projects.Commands.Delete;
using LubyClocker.Application.BoundedContexts.Projects.Commands.DeleteMember;
using LubyClocker.Application.BoundedContexts.Projects.Commands.Update;
using LubyClocker.Application.BoundedContexts.Projects.Queries.FindAll;
using LubyClocker.Application.BoundedContexts.Projects.Queries.FindById;
using LubyClocker.Application.BoundedContexts.Projects.Queries.FindMembers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubyClocker.Api.Controllers
{
    [Route("api/v1/projects")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(Add), result);
        }
        
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Edit([FromBody] UpdateProjectCommand command, [FromRoute] Guid id)
        {
            var result = await _mediator.Send(command.IncludeId(id));
            
            return Ok(result);
        }
        
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new  DeleteProjectCommand().IncludeId(id));
            
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> FindAll([FromQuery] FindProjectsQuery query)
        {
            var result = await _mediator.Send(query);
            
            return Ok(result);
        }
        
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> FindById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new FindProjectByIdQuery().IncludeId(id));
            
            return Ok(result);
        }
        
        [HttpPost("{id:guid}/members")]
        public async Task<IActionResult> AddMember([FromRoute] Guid id, [FromBody] AddMemberProjectCommand command)
        {
            var result = await _mediator.Send(command.IncludeProjectId(id));
            
            return CreatedAtAction(nameof(AddMember), result);
        }
        
        [HttpGet("{id:guid}/members")]
        public async Task<IActionResult> GetMembers([FromRoute] Guid id, [FromQuery] FindProjectMembersQuery query)
        {
            var result = await _mediator.Send(query.IncludeProjectId(id));
            
            return Ok(result);
        }
        
        [HttpDelete("{id:guid}/members/{memberId:guid}")]
        public async Task<IActionResult> DeleteMember([FromRoute] Guid id, [FromRoute] Guid memberId)
        {
            var result = await _mediator.Send(new DeleteProjectMemberCommand()
            {
                ProjectId = id,
                ProjectMemberId = memberId
            });
            
            return Ok(result);
        }
        
        [HttpPost("{id:guid}/members/{memberId:guid}/time-entry")]
        public async Task<IActionResult> AddTimeEntry([FromRoute] Guid id, [FromRoute] Guid memberId, [FromBody] CreateTimeEntryCommand command)
        {
            var result = await _mediator.Send(command.IncludeProjectId(id).IncludeProjectMemberId(memberId));
            
            return CreatedAtAction(nameof(AddTimeEntry), result);
        }
    }
}
