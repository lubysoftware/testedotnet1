using Microsoft.AspNetCore.Authorization;
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
        public ActionResult<IEnumerable<DesenvolvedorDTO>> GetTodos()
        {
            return Ok(_appServicoDesenvolvedor.GetAll());
        }

        [HttpGet("{id}", Name="Get")]
        public ActionResult<DesenvolvedorDTO> Get(int id)
        {
            return Ok(_appServicoDesenvolvedor.GetById(id));
        }

        [HttpPost]
        public ActionResult<DesenvolvedorDTO> AdicionarDesenvolvedor([FromBody] DesenvolvedorDTO desenvolvedorDTO)
        {
            var desenvolverdorDtoRetorno = _appServicoDesenvolvedor.Add(desenvolvedorDTO);
            return CreatedAtRoute("Get", new { id = desenvolverdorDtoRetorno.Id }, desenvolverdorDtoRetorno);
        }
    }
}
