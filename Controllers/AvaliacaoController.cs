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
    [Route("avaliacoes")]
    public class AvaliacaoController : ControllerBase
    {

        [HttpGet]
        [Route("projeto/{id:int}")]
        public async Task<ActionResult<List<Avaliacao>>> GetByProjeto([FromServices] DataContext context, int id)
        {
            var avaliacoes = await context.Avaliacoes
                            .AsNoTracking()
                            .Where(x => x.ProjetoId == id)
                            .ToListAsync();
            return avaliacoes;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Avaliacao>> Post([FromServices] DataContext context, [FromBody] Avaliacao model)
        {
            if(ModelState.IsValid){
                context.Avaliacoes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else{
                return BadRequest(ModelState);
            }
        }
    }
}