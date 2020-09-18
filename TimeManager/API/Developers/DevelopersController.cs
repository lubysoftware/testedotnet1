using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TimeManager.Application.Developers;
using TimeManager.Application.Developers.Commands.Create;
using TimeManager.Application.Developers.Commands.Delete;
using TimeManager.Application.Developers.Commands.Update;
using TimeManager.Application.Developers.Queries;

namespace API.Developers
{
    [Route("api/developers")]
    [ApiController]
    public class DevelopersController : Controller
    {
        private readonly IMediator _mediator;

        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all developers.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(DevelopersViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetDevelopersQuery());

            if (result == null)
                return BadRequest();

            return Ok(result);
        }

        /// <summary>
        /// Register a new developer.
        /// </summary>
        /// <param name="request">Name of the developer</param>
        [HttpPost]
        [ProducesResponseType(typeof(DeveloperDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> Create([FromBody] DeveloperRequest request)
        {
            await _mediator.Send(new CreateDeveloperCommand(request.Name));

            return Created(string.Empty, null);
        }

        /// <summary>
        /// Update developer.
        /// </summary>
        /// <param name="developerId">Developer ID</param>
        /// <param name="request">Name of the developer</param>
        [HttpPut("{developerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromRoute] Guid developerId, [FromBody] DeveloperRequest request)
        {
            await _mediator.Send(new UpdateDeveloperCommand(developerId, request.Name));

            return Ok();
        }

        /// <summary>
        /// Delete a developer.
        /// </summary>
        /// <param name="developerId">Developer ID</param>
        [HttpDelete("{developerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] Guid developerId)
        {
            await _mediator.Send(new DeleteDeveloperCommand(developerId));

            return Ok();
        }
    }
}
