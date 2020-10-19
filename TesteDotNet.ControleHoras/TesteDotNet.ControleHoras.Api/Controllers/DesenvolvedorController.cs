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

        [HttpGet("{id}", Name="Get")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_appServicoDesenvolvedor.GetById(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }            
        }

        [HttpPost]
        public IActionResult AdicionarDesenvolvedor([FromBody] DesenvolvedorDTO desenvolvedorDTO)
        {
            try
            {
                var resultado = _appServicoDesenvolvedor.Inserir(desenvolvedorDTO);

                if(resultado.ErroMensagem.Any())
                    return StatusCode(400, resultado.MensagemErro400SalvandoCadastro());

                var desenvolvedorDtoResultado = (DesenvolvedorDTO)resultado.EntidadeDTO;
                return CreatedAtRoute("Get", new { id = desenvolvedorDtoResultado.Id }, desenvolvedorDtoResultado);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }            
        }

        [HttpPut]
        public IActionResult AtualizarDesenvolvedor([FromBody] DesenvolvedorDTO desenvolvedorDTO)
        {
            try
            {
                if(!_appServicoDesenvolvedor.Exists(desenvolvedorDTO.Id))
                    return NotFound(StatusCode(400, $"Desenvolvedor não encontrado para o ID {desenvolvedorDTO.Id}."));

                var resultado = _appServicoDesenvolvedor.Update(desenvolvedorDTO);
                                
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
        public IActionResult AtualizarDesenvolvedorParcialmente(int id, [FromBody] JsonPatchDocument<DesenvolvedorDTO> dtoPatch)
        {
            try
            {
                if (!_appServicoDesenvolvedor.Exists(id))
                    return NotFound(StatusCode(400, $"Desenvolvedor não encontrado para o ID {id}."));

                var resultado = _appServicoDesenvolvedor.UpdatePatch(id, dtoPatch);

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
        public IActionResult RemoverDesenvolvedor(int id)
        {
            try
            {
                if (!_appServicoDesenvolvedor.Exists(id))
                    return NotFound(StatusCode(400, $"Desenvolvedor não encontrado para o ID {id}."));

                var resultado = _appServicoDesenvolvedor.Delete(id);

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
