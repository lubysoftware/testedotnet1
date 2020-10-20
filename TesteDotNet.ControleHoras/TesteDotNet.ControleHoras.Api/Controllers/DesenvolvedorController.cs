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
    [Route("api/desenvolvedores")]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly IAppServicoDesenvolvedor _appServicoDesenvolvedor;

        public DesenvolvedorController(IAppServicoDesenvolvedor appServicoDesenvolvedor)
        {
            _appServicoDesenvolvedor = appServicoDesenvolvedor;
        }

        [HttpGet]
        public async Task<ActionResult<List<DesenvolvedorDTO>>> GetTodos()
        {
            try
            {
                return await _appServicoDesenvolvedor.GetAllAsync();
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }            
        }

        [HttpGet("{id}", Name="GetDesenvolvedor")]
        public async Task<ActionResult<DesenvolvedorDTO>> Get(int id)
        {
            try
            {
                return await _appServicoDesenvolvedor.GetByIdAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }            
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarDesenvolvedor([FromBody] DesenvolvedorDTO desenvolvedorDTO)
        {
            try
            {
                var resultado = await _appServicoDesenvolvedor.InserirAsync(desenvolvedorDTO);

                if(resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                var desenvolvedorDtoResultado = (DesenvolvedorDTO)resultado.EntidadeDTO;
                return CreatedAtRoute("GetDesenvolvedor", new { id = desenvolvedorDtoResultado.Id }, desenvolvedorDtoResultado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }            
        }

        [HttpPut]
        public async Task<ActionResult> AtualizarDesenvolvedor([FromBody] DesenvolvedorDTO desenvolvedorDTO)
        {
            try
            {
                if(!await _appServicoDesenvolvedor.ExistsAsync(desenvolvedorDTO.Id))
                    return NotFound(StatusCode(400, $"Desenvolvedor não encontrado para o ID {desenvolvedorDTO.Id}."));

                var resultado = await _appServicoDesenvolvedor.UpdateAsync(desenvolvedorDTO);
                                
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
        public async Task<ActionResult> AtualizarDesenvolvedorParcialmente(int id, [FromBody] JsonPatchDocument<DesenvolvedorDTO> dtoPatch)
        {
            try
            {
                if (!await _appServicoDesenvolvedor.ExistsAsync(id))
                    return NotFound(StatusCode(400, $"Desenvolvedor não encontrado para o ID {id}."));

                var resultado = await _appServicoDesenvolvedor.UpdatePatchAsync(id, dtoPatch);

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
        public async Task<ActionResult> RemoverDesenvolvedor(int id)
        {
            try
            {
                if (!await _appServicoDesenvolvedor.ExistsAsync(id))
                    return NotFound(StatusCode(400, $"Desenvolvedor não encontrado para o ID {id}."));

                var resultado = await _appServicoDesenvolvedor.DeleteAsync(id);

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
