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

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Desenvolvedor>> Post(
            [FromServices] DataContext context,
            [FromBody] Desenvolvedor model)
        {
            if (ModelState.IsValid)
            {
                context.Desenvolvedores.Add(model);
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
        public async Task<ActionResult<Desenvolvedor>> DeleteByID([FromServices] DataContext context, int id)
        {
            var validaIdDesenvolvedor = context.Desenvolvedores.FirstOrDefault(x => x.Id == id);

            if (validaIdDesenvolvedor != null)
            {
                context.Desenvolvedores.Remove(validaIdDesenvolvedor);
                await context.SaveChangesAsync();
                return Ok("Desenvolvedor " + validaIdDesenvolvedor.Nome + " Excluido com sucesso!");
            }
            else
            {
                return BadRequest("Desenvolvedor não encontrado!");
            }
        }

        [HttpPut]
        [Route("")]
        public ActionResult<Desenvolvedor> UpdateById([FromServices] DataContext context,
            [FromBody] Desenvolvedor model)
        {
            try
            {
                var DesenvolvedorParaSerAtualizadoExiste = context.Desenvolvedores.Any(x => x.Id == model.Id);

                if (ModelState.IsValid && DesenvolvedorParaSerAtualizadoExiste)
                {
                    context.Desenvolvedores.Update(model);
                    context.SaveChanges();
                    return Ok("Desenvolvedor " + "" + " Atualizado para " + model.Nome + " com sucesso!");
                }
                else
                {
                    throw new Exception("Desenvolvedor não encontrado!");
                }
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }


        }


    }

}

