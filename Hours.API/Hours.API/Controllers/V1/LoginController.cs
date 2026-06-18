using Hours.Application.DataContract.Response.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using User.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Login.API.Controllers.V1
{
    [Route("v1/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginApplication _LoginApplication;

        public LoginController(ILoginApplication LoginApplication)
        {
            _LoginApplication = LoginApplication;
        }

        /// <summary>
        /// Login with Token
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Login([FromBody] LoginResponse data)
        {
            var response = await _LoginApplication.FindByLoginAsync(data);

            if (response.Reports.Count > 0)
                return UnprocessableEntity(response.Reports);

            return Ok(response.Data);
        }      
    }
}
