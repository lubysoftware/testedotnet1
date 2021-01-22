using ApiRestDevs.Data;
using ApiRestDevs.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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

    }
}
