using ApiRestDevs.Data;
using ApiRestDevs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestDevs.Controllers
{
    [Route("api/lancarhora")]
    [ApiController]
    public class LancamentoDeHoraController : Controller
    {

        [HttpPost]
        [Route("")]
        public ActionResult<LancamentoDeHora> Post(
            [FromServices] DataContext context,
            [FromBody] LancamentoDeHora model)
        {            
            try
            {

                var validaIdDesenvolvedor = context.Desenvolvedores.Any(x => x.Id == model.DesenvolvedorId) ? true : throw new Exception("Desenvolvedor não Existe!");
                var validaIdProjeto =  context.Projetos.Any(x => x.Id == model.ProjetoTrabalhadoId) ? true : throw new Exception("Projeto não Existe!");
                var validaHorasTrabalhadas = model.QtdHorasTrabalhadas > 0 ? true : throw new Exception("Horas devem ser Positivass"); ;
 
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
        public async Task<ActionResult<List<LancamentoDeHora>>> Get(
            [FromServices] DataContext context)
        {
            try
            {
                var result = await context.LancamentoDeHoras.ToListAsync();
                return result;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
