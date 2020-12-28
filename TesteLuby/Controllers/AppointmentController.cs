using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteLuby.Interfaces;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<AppointmentDTO> Get(int id)
        {
            try
            {
                var data = _appointmentService.Get(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("ranking")]
        [HttpPost]
        public IActionResult GetRanking(AppointmentRankingDTO appointmentRankingDTO)
        {
            try
            {
                var data = _appointmentService.GetRanking(appointmentRankingDTO);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("save")]
        [HttpPost]
        public ActionResult Save(AppointmentDTO appointmentDTO)
        {
            try
            {
                if (_appointmentService.Insert(appointmentDTO))
                    return Ok("Salvo com sucesso");
                else
                    return BadRequest("Nao foi possivel salvar o Apontamento. Por favor, verifique os campos.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("edit/{id}")]
        [HttpPut]
        public ActionResult Edit(AppointmentDTO appointmentDTO, int id)
        {
            try
            {
                if (_appointmentService.Update(appointmentDTO, id))
                    return Ok("Atualizado com Sucesso");
                else
                    return BadRequest("Nao foi possivel salvar o Apontamento. Por favor, verifique os campos.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
