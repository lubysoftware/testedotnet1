using ApiRestDevs.Data;
using ApiRestDevs.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "all")]
        public async Task<ActionResult<List<Projeto>>> Get([FromServices] DataContext context)
        {
            try
            {
                var result = await context.Projetos.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize(Roles = "all")]
        public async Task<ActionResult<Projeto>> GetById([FromServices] DataContext context, int id)
        {
            try
            {
                var result = await context.Projetos.FirstOrDefaultAsync(x => x.Id == id);
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "all")]
        public async Task<ActionResult<Projeto>> Post(
            [FromServices] DataContext context,
            [FromBody] Projeto model)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "all")]
        public async Task<ActionResult<Projeto>> DeleteByID([FromServices] DataContext context, int id)
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }            
        }

        [HttpPut]
        [Route("")]
        [Authorize(Roles = "all")]
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
