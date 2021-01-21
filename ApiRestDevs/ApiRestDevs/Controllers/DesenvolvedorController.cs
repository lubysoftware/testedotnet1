using ApiRestDevs.Data;
using ApiRestDevs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestDevs.Controllers
{
    [ApiController]
    [Route("api/devs")]
    public class DesenvolvedorController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Desenvolvedor>>> Get([FromServices] DataContext context)
        {
            var result = await context.Desenvolvedores.ToListAsync();
            return result;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Desenvolvedor>> GetById([FromServices] DataContext context, int id)
        {
            var result = await context.Desenvolvedores.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
                          

    }

}

