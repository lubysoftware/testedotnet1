using System;
using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Developers.Commands.Create;
using LubyClocker.Application.BoundedContexts.Developers.Commands.Delete;
using LubyClocker.Application.BoundedContexts.Developers.Commands.Update;
using LubyClocker.Application.BoundedContexts.Developers.Queries.FindAll;
using LubyClocker.Application.BoundedContexts.Developers.Queries.FindById;
using LubyClocker.Application.BoundedContexts.Users.Commands.Login;
using LubyClocker.Application.BoundedContexts.Users.Commands.SignUp;
using LubyClocker.Application.BoundedContexts.Users.Queries.FindUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubyClocker.Api.Controllers
{
    [Route("api/v1/auth")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
        {
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(SignUp), result);
        }
        
        [HttpPost("log-in")]
        public async Task<IActionResult> LogIn([FromBody] LogInCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var result = await _mediator.Send(new FindUserQuery());
            
            return Ok(result);
        }
    }
}
