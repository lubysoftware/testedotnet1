using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luby.Controllers
{
    [Produces("application/json")]
    [Route("home")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("Teste Luby");
        }
    }
}
