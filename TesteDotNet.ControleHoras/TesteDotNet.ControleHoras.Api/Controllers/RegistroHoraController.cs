using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<RegistroHoraDTO>>> GetTodosAsync()
        {
            try
            {
                return await _appServicoRegistro.GetAllAsync();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [Authorize]
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

        [Authorize]
        [HttpPost("{desenvolvedorid}")]
        public async Task<ActionResult> AdicionarRegistroVarios(int desenvolvedorid, [FromBody] List<RegistroHoraDTO> registrosHorasDTO)
        {
            try
            {
                var rotas = new List<CreatedAtRouteResult>();
                foreach(var reg in registrosHorasDTO)
                {
                    reg.DesenvolvedorId = desenvolvedorid;

                    var resultado = await _appServicoRegistro.InserirAsync(reg);

                    if (resultado.ErroMensagem.Any())
                        return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                    var registroHoraDtoResultado = (RegistroHoraDTO)resultado.EntidadeDTO;

                    rotas.Add(CreatedAtRoute("GetRegistroHoras", new { id = registroHoraDtoResultado.Id }, registroHoraDtoResultado));
                }

                return Ok(rotas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [Authorize]
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

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> AtualizarRegistro([FromBody] RegistroHoraDTO registroHoraDTO)
        {
            try
            {
                if (!await _appServicoRegistro.ExistsAsync(registroHoraDTO.Id))
                    return NotFound(StatusCode(400, $"Registro de Horas não encontrado para o ID {registroHoraDTO.Id}."));

                var resultado = await _appServicoRegistro.UpdateAsync(registroHoraDTO);

                if (resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                return Ok(resultado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [Authorize]
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
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [Authorize]
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
            catch (Exception)
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
