using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTO;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LubyPontoEletronico.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class PontoController : ControllerBase<Ponto, PontoDTO>
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly IPontoApplication pontoApplication;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public PontoController(IPontoApplication app)
          : base(app)
        {
            pontoApplication = app;
        }

        /// <summary>
        /// Retorna ranking dos 5 desenvolvedores da semana com maior média de horas trabalhadas.
        /// </summary>
        /// <returns></returns>
        [HttpGet("MaiorMediaSemana")]
        public IActionResult GetMaiorMedia()
        {
            try
            {
                return Ok(pontoApplication.GetMediaPonto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
