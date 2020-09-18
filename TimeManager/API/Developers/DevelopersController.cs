using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using TimeManager.Application.Developers;
using TimeManager.Application.Developers.ChangeDeveloperDetails;
using TimeManager.Application.Developers.GetDevelopers;
using TimeManager.Application.Developers.RegisterDeveloper;
using TimeManager.Application.Developers.RemoveDeveloper;

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
        public async Task<IActionResult> RegisterDeveloper([FromBody] DeveloperDetailsRequest request)
        {
            await _mediator.Send(new RegisterDeveloperCommand(request.Name));

            return Created(string.Empty, null);
        }

        /// <summary>
        /// Change developer details.
        /// </summary>
        /// <param name="developerId">Developer ID</param>
        /// <param name="request">Name of the developer</param>
        [HttpPut("{developerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeDeveloperDetails([FromRoute] Guid developerId, [FromBody] DeveloperDetailsRequest request)
        {
            await _mediator.Send(new ChangeDeveloperDetailsCommand(developerId, request.Name));

            return Ok();
        }

        /// <summary>
        /// Remove a developer.
        /// </summary>
        /// <param name="developerId">Developer ID</param>
        [HttpDelete("{developerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveDeveloper([FromRoute] Guid developerId)
        {
            await _mediator.Send(new RemoveDeveloperCommand(developerId));

            return Ok();
        }
    }
}
