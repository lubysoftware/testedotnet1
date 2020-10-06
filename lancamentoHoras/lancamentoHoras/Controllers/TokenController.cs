using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lancamentoHoras.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lancamentoHoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] string user)
        {
            var token = TokenService.GenerateToken(user);

            return new
            {
                user = user,
                token = token
            };
        }
    }
}