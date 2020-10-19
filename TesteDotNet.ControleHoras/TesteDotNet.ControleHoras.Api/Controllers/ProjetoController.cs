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
    [Route("api/projetos")]
    public class ProjetoController : ControllerBase
    {
        private readonly IAppServicoProjeto _appServicoProjeto;

        public ProjetoController(IAppServicoProjeto appServicoProjeto)
        {
            _appServicoProjeto = appServicoProjeto;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjetoDTO>>> GetTodos()
        {
            try
            {
                return await _appServicoProjeto.GetAllAsync();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ProjetoDTO>> Get(int id)
        {
            try
            {
                return await _appServicoProjeto.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarProjeto([FromBody] ProjetoDTO projetoDTO)
        {
            try
            {
                var resultado = await _appServicoProjeto.InserirAsync(projetoDTO);

                if (resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                var dtoResultado = (ProjetoDTO)resultado.EntidadeDTO;
                return CreatedAtRoute("Get", new { id = dtoResultado.Id }, dtoResultado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarProjeto([FromBody] ProjetoDTO projetoDTO)
        {
            try
            {
                if (!await _appServicoProjeto.ExistsAsync(projetoDTO.Id))
                    return NotFound(StatusCode(400, $"Projeto não encontrado para o ID {projetoDTO.Id}."));

                var resultado = await _appServicoProjeto.UpdateAsync(projetoDTO);

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
        public async Task<ActionResult> AtualizarProjetoParcialmente(int id, [FromBody] JsonPatchDocument<ProjetoDTO> dtoPatch)
        {
            try
            {
                if (!await _appServicoProjeto.ExistsAsync(id))
                    return NotFound(StatusCode(400, $"Projeto não encontrado para o ID {id}."));

                var resultado = await _appServicoProjeto.UpdatePatchAsync(id, dtoPatch);

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
        public async Task<ActionResult> RemoverProjeto(int id)
        {
            try
            {
                if (!await _appServicoProjeto.ExistsAsync(id))
                    return NotFound(StatusCode(400, $"Projeto não encontrado para o ID {id}."));

                var resultado = await _appServicoProjeto.DeleteAsync(id);

                if (resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                return Ok($"Desenvolvedor ID {id} removido com sucesso.");
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
