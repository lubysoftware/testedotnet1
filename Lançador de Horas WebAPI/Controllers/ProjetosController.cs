using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    /// <summary>
    /// API CRUD para projeto
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoService _projetoService;

        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="projetoService">Serviço de CRUD ao banco</param>
        public ProjetosController(ProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        // GET: api/Projetos

        /// <summary>
        /// Obtém todos os projetos registrados
        /// </summary>
        /// <returns>A lista de projetos</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _projetoService.Get();
        }

        // GET: api/Projetos/5
        /// <summary>
        /// Obtém um projeto pelo Id
        /// </summary>
        /// <param name="id">Id do projeto</param>
        /// <returns>O projeto</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> GetProjeto(int id)
        {
            var projeto = await _projetoService.GetById(id);

            if (projeto == null)
            {
                return NotFound();
            }

            return projeto;
        }

        // PUT: api/Projetos/5
        /// <summary>
        /// Atualiza um projeto
        /// </summary>
        /// <param name="id">Id do projeto a ser alterado</param>
        /// <param name="projeto">Objeto com as alterações</param>
        /// <returns>O projeto criado</returns>
        /// /// <response code="201">Retorna o novo projeto atualizado</response>
        /// <response code="204">Se a atualização for bem sucedida</response>
        /// <response code="400">Se o projeto for nulo</response>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjeto(int id, Projeto projeto)
        {
            if (id != projeto.Id)
            {
                return BadRequest();
            }

            if (await _projetoService.Update(id, projeto) == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Projetos
        /// <summary>
        /// Insere um projeto
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "nome": "João",
        ///        "custo": 23223.88,
        ///     }
        ///
        /// </remarks>
        /// <param name="projeto">Objeto projeto a ser inserido</param>
        /// <returns>O projeto criado</returns>
        /// /// <response code="201">Retorna o novo projeto criado</response>
        /// <response code="400">Se o projeto for nulo</response>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpPost]
        public async Task<ActionResult<Projeto>> PostProjeto(Projeto projeto)
        {
            await _projetoService.Create(projeto);

            return CreatedAtAction("GetDesenvolvedor", new { id = projeto.Id }, projeto);
        }

        // DELETE: api/Projetos/5
        /// <summary>
        /// Deleta um projeto
        /// </summary>
        /// <param name="id">Id do projeto a ser alterado</param>
        /// <returns>Retorna o projeto deletado</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Projeto>> DeleteProjeto(int id)
        {
            var projeto = await _projetoService.GetById(id);

            if (projeto == null)
            {
                return NotFound();
            }

            await _projetoService.Delete(projeto);

            return projeto;
        }
    }
}