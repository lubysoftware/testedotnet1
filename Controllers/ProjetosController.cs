using LancamentoHorasAPI.Interfaces;
using LancamentoHorasAPI.Models;
using LancamentoHorasAPI.Dto;
using LancamentoHorasAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LancamentoHorasAPI.Controllers
{
    [Route("projetos")]
    public class ProjetosController : Controller
    {
        private readonly IProjetoService _projetoService;

        public ProjetosController(IProjetoService projetoService)
        {
            _projetoService = projetoService ??
                throw new ArgumentNullException(nameof(projetoService));
        }

        /// <summary>
        ///  Realiza lancamento de horas
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lancamentoPost"></param>
        /// <response code="201">Sucesso</response>
        /// <response code="500">Erro interno</response>
        [HttpPost("{id}/Lancamentos")]
        public async Task<IActionResult> InsertLancamentoAsync(int id, LancamentoPost lancamentoPost)
        {
            await _projetoService.InsertHorasAsync(id, lancamentoPost);
            return NoContent();
        }

        /// <summary>
        /// Cria um projeto e insere no banco de dados
        /// </summary>
        /// <param name="projeto"></param>
        /// <returns></returns>
        /// <response code="201">Projeto</response>
        /// <response code="500">Erro interno</response>
        [HttpPost()]
        public async Task<IActionResult> Create(ProjetoPost projeto)
        {
            await _projetoService.InsertAsync(projeto);
            return NoContent();
        }

        /// <summary>
        /// Retorna lista de todos os projetos
        /// </summary>
        /// <returns></returns>
        //GET: Read
        /// <response code="200">Desenvolvedores</response>
        /// <response code="500">Erro interno</response>
        [HttpGet()]
        public async Task<IActionResult> FindAll()
        {
            try
            {
                var projetos = await _projetoService.FindAllAsync();
                return Ok(projetos);
            }
            catch
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Retorna um projeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna um projeto</returns>
        /// <response code="200">Desenvolvedor</response>
        /// <response code="500">Erro interno</response>
        //GET: Read
        [HttpGet("{id}")]
        public async Task<IActionResult> FindProjeto(int? id)
        {
            var projeto = await _projetoService.FindByIdAsync(id.Value);
            return Ok(projeto);
        }

        /// <summary>
        /// Edita um projeto nob anco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Desenvolvedor</response>
        /// <response code="500">Erro interno</response>
        //PUT: Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            var projeto = await _projetoService.FindByIdAsync(id.Value);
            await _projetoService.UpdateAsync(projeto);
            return Ok(projeto);
        }

        /// <summary>
        /// Remove um projeto do banco de dados
        /// </summary>
        /// <param name="id"></param>
        /// <response code="204">Desenvolvedor</response>
        /// <response code="500">Erro interno</response>
        //DELETE: Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            await _projetoService.RemoveAsync(id.Value);
            return Ok();
        }
    }
}
