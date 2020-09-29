using LTS.API.Authorizations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LTS.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/auth")]

    public class AuthController : ControllerBase
    {

        private readonly IAuthUser _authUser;
        public AuthController(IAuthUser authUser)
        {
            _authUser = authUser;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginUser)
        {
            var result = await _authUser.LoginAsync(loginUser);
            return Ok(result);
        }
    }
}
