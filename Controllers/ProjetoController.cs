using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using testedotnet1.Data;
using testedotnet1.Models;

namespace testedotnet1.Controllers
{
    [ApiController]
    [Route("projetos")]
    public class ProjetoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Projeto>>> Get([FromServices] DataContext context)
        {
            var projetos = await context.Projetos.ToListAsync();
            return projetos;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Projeto>> GetById([FromServices] DataContext context, int id)
        {
            var projeto = await context.Projetos
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.Id == id);
            return projeto;
        }

        [HttpGet]
        [Route("desenvolvedor/{id:int}")]
        public async Task<ActionResult<List<Projeto>>> GetByDesenvolvedor([FromServices] DataContext context, int id)
        {
            var projetos = await context.Projetos
                            .AsNoTracking()
                            .Where(x => x.DesenvolvedorId == id)
                            .ToListAsync();
            return projetos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Projeto>> Post([FromServices] DataContext context, [FromBody] Projeto model)
        {
            if(ModelState.IsValid){
                context.Projetos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else{
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Projeto>> Put([FromServices] DataContext context, [FromBody] Projeto model, int id)
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
            var projeto = await context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound();
            }

            context.Projetos.Remove(projeto);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}