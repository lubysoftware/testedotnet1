using ApiRestDevs.Data;
using ApiRestDevs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDevs.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Post(
            [FromServices] DataContext context,
            [FromBody] User model)
        {
            try
            {
                var userExistente = context.Users
                    .Any(x => x.Username == model.Username) ? throw new Exception("Usuário já existe!") : false;
      
                if (ModelState.IsValid && !userExistente)
                    {
                        context.Users.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

            
        }

    }
}
