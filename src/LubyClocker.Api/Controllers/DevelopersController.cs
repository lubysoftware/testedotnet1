using System.Text.Json;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LubyClocker.Api.Controllers
{
    [Route("api/v1/developers")]
    [Produces("application/json")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddDeveloper([FromBody] CreateDeveloperCommand command)
        {
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(AddDeveloper), result);
        }
    }
}
