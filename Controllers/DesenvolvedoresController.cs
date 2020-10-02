using LancamentoHorasAPI.Models;
using LancamentoHorasAPI.Interfaces;
using LancamentoHorasAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LancamentoHorasAPI.Dto;

namespace LancamentoHorasAPI.Controllers
{
    [Route("desenvolvedores")]
    public class DesenvolvedoresController : Controller
    {
        private readonly IDesenvolvedorService _desenvolvedoresService;

        public DesenvolvedoresController(IDesenvolvedorService desenvolvedoresService)
        {
            _desenvolvedoresService = desenvolvedoresService;
        }

        /// <summary>
        /// Cria um desenvolvedor e insere no banco de dados
        /// </summary>
        /// <response code="201">Desenvolvedor</response>
        /// <response code="500">Erro interno</response>

        [HttpPost]
        public async Task<IActionResult> Create(DesenvolvedorPost desenvolvedor)
        {
            await _desenvolvedoresService.InsertAsync(desenvolvedor);
            return Ok("Desenvolvedor Criado");
        }

        /// <summary>
        /// Retorna lista de todos os desenvolvedores cadastrados
        /// </summary>
        /// <returns>Retorna lista de todos desenvolvedores</returns>
        /// <response code="200">Lista de Desenvolvedores</response>
        /// <response code="500">Erro interno</response>

        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var desenvolvedores = await _desenvolvedoresService.FindAllAsync();
                return Ok(desenvolvedores);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna um desenvolvedor pelo ID
        /// </summary>
        /// <returns>Retorna um projeto</returns>
        /// <response code="200">Desenvolvedor</response>
        /// <response code="500">Erro interno</response>

        [HttpGet("{id}")]
        public async Task<IActionResult> FindDesenvolvedor(int? id)
        {
            var desenvolvedor = await _desenvolvedoresService.FindByIdAsync(id.Value);
            return Ok(desenvolvedor);
        }

        /// <summary>
        /// Atualiza os dados de um desenvolvedor no banco de dados
        /// </summary>
        /// <returns>Atualiza um desenvolvedor</returns>
        /// <response code="204"> Desenvolvedor</response>
        /// <response code="500">Erro interno</response>

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            var desenvolvedor = await _desenvolvedoresService.FindByIdAsync(id.Value);
            await _desenvolvedoresService.UpdateAsync(desenvolvedor);
            return Ok(desenvolvedor);
        }

        /// <summary>
        /// Remove um desenvolvedor do banco de dados
        /// </summary>
        /// <response code="204">Sucesso</response>
        /// <response code="500">Erro interno</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {

            await _desenvolvedoresService.RemoveAsync(id.Value);
            return Ok();
        }

        /// <summary>
        /// Obtém a lista do ranking dos 5 desenvolvedores que mais possuem horas trabalhadas
        /// </summary>
        /// <returns>Retorna a lista dos desenvolvedores</returns>
        /// <response code="200">Lista de Desenvolvedores</response>
        /// <response code="500">Erro interno</response>
        [HttpGet("ranking")]
        public async Task<IActionResult> GetRanking()
        {
            var desenvolvedores = await _desenvolvedoresService.GetTop5Async();
            return Ok(desenvolvedores);
        }
    }
}
