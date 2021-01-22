using ApiRestDevs.Data;
using ApiRestDevs.Models;
using ApiRestDevs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiRestDevs.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public ActionResult<dynamic> Autenticar([FromServices] DataContext context,[FromBody] User model)
        {
            var user = context.Users
                .Where(x => x.Username.ToLower() == model.Username.ToLower() && x.Password == model.Password)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound(new { message = "Usuário ou Senha Inválidos" });
            }

            var token = TokenService.GeraToken(user);
            user.Password = "";

            return new { 
                user = user.Username, 
                token = token 
            };
        }
    }
}
