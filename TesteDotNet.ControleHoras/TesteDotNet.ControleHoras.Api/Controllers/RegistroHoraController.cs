using Microsoft.AspNetCore.JsonPatch;
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
    [Route("api/desenvolvedores/registrohoras")]
    public class RegistroHoraController : ControllerBase
    {
        private readonly IAppServicoRegistroHoras _appServicoRegistro;

        public RegistroHoraController(IAppServicoRegistroHoras appServicoRegistro)
        {
            _appServicoRegistro = appServicoRegistro;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistroHoraDTO>>> GetRanking()
        {
            try
            {
                return await _appServicoRegistro.GetRankingDesenvolvedoresSemanaComMaisHorasTrabalhadas(5);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpGet("{id}", Name = "GetRegistroHoras")]
        public async Task<ActionResult<RegistroHoraDTO>> Get(int id)
        {
            try
            {
                return await _appServicoRegistro.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarRegistro([FromBody] RegistroHoraDTO registroHorasDTO)
        {
            try
            {
                var resultado = await _appServicoRegistro.InserirAsync(registroHorasDTO);

                if (resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                var registroHoraDtoResultado = (RegistroHoraDTO)resultado.EntidadeDTO;
                return CreatedAtRoute("GetRegistroHoras", new { id = registroHoraDtoResultado.Id }, registroHoraDtoResultado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarRegistro([FromBody] RegistroHoraDTO desenvolvedorDTO)
        {
            try
            {
                if (!await _appServicoRegistro.ExistsAsync(desenvolvedorDTO.Id))
                    return NotFound(StatusCode(400, $"Registro de Horas não encontrado para o ID {desenvolvedorDTO.Id}."));

                var resultado = await _appServicoRegistro.UpdateAsync(desenvolvedorDTO);

                if (resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> AtualizarRegistroParcialmente(int id, [FromBody] JsonPatchDocument<RegistroHoraDTO> dtoPatch)
        {
            try
            {
                if (!await _appServicoRegistro.ExistsAsync(id))
                    return NotFound(StatusCode(400, $"Registro de Horas não encontrado para o ID {id}."));

                var resultado = await _appServicoRegistro.UpdatePatchAsync(id, dtoPatch);

                if (resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoverRegistro(int id)
        {
            try
            {
                if (!await _appServicoRegistro.ExistsAsync(id))
                    return NotFound(StatusCode(400, $"Registro de Horas não encontrado para o ID {id}."));

                var resultado = await _appServicoRegistro.DeleteAsync(id);

                if (resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                return Ok($"Registro de Horas ID {id} removido com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpOptions]
        public IActionResult ListarOperacoesPermitidas()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT, PATCH, DELETE, OPTIONS");
            return Ok();
        }
    }
}
