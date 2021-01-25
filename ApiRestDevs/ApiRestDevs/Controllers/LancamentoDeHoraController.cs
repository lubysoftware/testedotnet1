using ApiRestDevs.Data;
using ApiRestDevs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiRestDevs.Controllers
{
    [Route("api/lancarhora")]
    [ApiController]
    public class LancamentoDeHoraController : Controller
    {

        [HttpPost]
        [Route("")]
        [Authorize(Roles = "all")]
        public ActionResult<LancamentoDeHora> Post(
            [FromServices] DataContext context,
            [FromBody] LancamentoDeHora model)
        {            
            try
            {

                var validaIdDesenvolvedor = context.Desenvolvedores
                    .Any(x => x.Id == model.DesenvolvedorId) ? true : throw new Exception("Desenvolvedor não Existe!");
                var validaIdProjeto =  context.Projetos
                    .Any(x => x.Id == model.ProjetoTrabalhadoId) ? true : throw new Exception("Projeto não Existe!");
                
                if (ModelState.IsValid)
                {

                    context.Add(model);
                    context.SaveChanges();
                    return Json(model);
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

        [HttpGet]
        [Route("ranking")]
        [Authorize(Roles = "all")]
        public ActionResult<List<object>> Get([FromServices] DataContext context)
        {
            try
            {
                var resultado = LancamentoDeHora.CalculaRankingDeHoras(context);

                return resultado;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
