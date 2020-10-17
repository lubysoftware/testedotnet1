using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/desenvolvedores")]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly IAppServicoDesenvolvedor _appServicoDesenvolvedor;

        public DesenvolvedorController(IAppServicoDesenvolvedor appServicoDesenvolvedor)
        {
            _appServicoDesenvolvedor = appServicoDesenvolvedor;
        }

        [HttpGet]
        public ActionResult<List<DesenvolvedorDTO>> GetTodos()
        {
            return Ok(_appServicoDesenvolvedor.GetAll());
        }
    }
}
