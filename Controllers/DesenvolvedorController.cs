using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testedotnet1.Data;
using testedotnet1.Models;

namespace testedotnet1.Controllers
{
    [ApiController]
    [Route("desenvolvedores")]
    public class DesenvolvedorController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Desenvolvedor>>> Get([FromServices] DataContext context)
        {
            var desenvolvedores = await context.Desenvolvedores.ToListAsync();
            return desenvolvedores;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Desenvolvedor>> GetById([FromServices] DataContext context, int id)
        {
            var desenvolvedor = await context.Desenvolvedores
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);
            return desenvolvedor;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Desenvolvedor>> Post([FromServices] DataContext context, [FromBody] Desenvolvedor model)
        {
            if(ModelState.IsValid){
                context.Desenvolvedores.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else{
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Desenvolvedor>> Put([FromServices] DataContext context, [FromBody] Desenvolvedor model, int id)
        {

            if (id != model.Id)
            {
                return BadRequest(ModelState);
            }

            context.Entry(model).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return model;
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromServices] DataContext context, int id)
        {
            var desenvolvedor = await context.Desenvolvedores.FindAsync(id);
            if (desenvolvedor == null)
            {
                return NotFound();
            }

            context.Desenvolvedores.Remove(desenvolvedor);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}