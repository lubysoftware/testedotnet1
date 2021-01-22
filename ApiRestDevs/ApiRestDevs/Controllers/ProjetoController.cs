using ApiRestDevs.Data;
using ApiRestDevs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDevs.Controllers
{
    [Route("api/projetos")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Projeto>>> Get([FromServices] DataContext context)
        {
            var result = await context.Projetos.ToListAsync();
            return result;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Projeto>> GetById([FromServices] DataContext context, int id)
        {
            var result = await context.Projetos.FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Projeto>> Post(
            [FromServices] DataContext context,
            [FromBody] Projeto model)
        {
            if (ModelState.IsValid)
            {
                context.Projetos.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Projeto>> DeleteByID([FromServices] DataContext context, int id)
        {
            var validaIdProjeto = context.Projetos.FirstOrDefault(x => x.Id == id);

            if (validaIdProjeto != null)
            {
                context.Projetos.Remove(validaIdProjeto);
                await context.SaveChangesAsync();
                return Ok("Projeto " + validaIdProjeto.Nome + " Excluido com sucesso!");
            }
            else
            {
                return BadRequest("Projeto não encontrado!");
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult<Projeto> UpdateById([FromServices] DataContext context,
            [FromBody] Projeto model)
        {
            try
            {
                var ProjetoParaSerAtualizadoExiste = context.Projetos.Any(x => x.Id == model.Id);

                if (ModelState.IsValid && ProjetoParaSerAtualizadoExiste)
                {
                    context.Projetos.Update(model);
                    context.SaveChanges();
                    return Ok("Projeto " + "" + " Atualizado para " + model.Nome + " com sucesso!");
                }
                else
                {
                    throw new Exception("Projeto não encontrado!");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }


        }


    }
}
