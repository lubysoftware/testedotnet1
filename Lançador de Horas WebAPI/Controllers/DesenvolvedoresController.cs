using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DesenvolvedoresController : ControllerBase
    {
        private readonly DesenvolvedorService _desenvolvedor;

        public DesenvolvedoresController(DesenvolvedorService desenvolvedor)
        {
            _desenvolvedor = desenvolvedor;
        }

        // GET: api/Desenvolvedores
        /// <summary>
        /// Obtém todos os desenvolvedores registrados
        /// </summary>
        /// <returns>A lista de desenvolvedores</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desenvolvedor>>> GetDesenvolvedores()
        {
            return await _desenvolvedor.Get();
        }

        // GET: api/Desenvolvedores/5
        /// <summary>
        /// Obtém um desenvolvedor pelo Id
        /// </summary>
        /// <param name="id">Id do desenvolvedor</param>
        /// <returns>O desenvolvedor</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Desenvolvedor>> GetDesenvolvedor(int id)
        {
            var desenvolvedor = await _desenvolvedor.GetById(id);

            if (desenvolvedor == null)
            {
                return NotFound();
            }

            return desenvolvedor;
        }

        // PUT: api/Desenvolvedores/5
        /// <summary>
        /// Atualiza um desenvolvedor
        /// </summary>
        /// <param name="id">Id do desenvolvedor a ser alterado</param>
        /// <param name="desenvolvedor">Objeto com as alterações</param>
        /// <returns>O desenvolvedor criado</returns>
        /// /// <response code="201">Retorna o novo desenvolvedor atualizado</response>
        /// <response code="400">Se o desenvolvedor for nulo</response>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesenvolvedor(int id, Desenvolvedor desenvolvedor)
        {
            if (id != desenvolvedor.Id)
            {
                return BadRequest();
            }

            if (await _desenvolvedor.Update(id, desenvolvedor) == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Desenvolvedores
        /// <summary>
        /// Insere um desenvolvedor
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "id": 1,
        ///        "name": "João",
        ///        "sobrenome": "da silva",
        ///        "cpf": "123.456.789-00"
        ///     }
        ///
        /// </remarks>
        /// <param name="desenvolvedor">Objeto com as alterações</param>
        /// <returns>O desenvolvedor criado</returns>
        /// /// <response code="201">Retorna o novo desenvolvedor criado</response>
        /// <response code="400">Se o desenvolvedor for nulo</response>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpPost]
        public async Task<ActionResult<Desenvolvedor>> PostDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            await _desenvolvedor.Create(desenvolvedor);

            return CreatedAtAction("GetDesenvolvedor", new { id = desenvolvedor.Id }, desenvolvedor);
        }

        // DELETE: api/Desenvolvedores/5
        /// <summary>
        /// Deleta um desenvolvedor
        /// </summary>
        /// <param name="id">Id do desenvolvedor a ser alterado</param>
        /// <returns>Retorna o desenvolvedor deletado</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Desenvolvedor>> DeleteDesenvolvedor(int id)
        {
            var desenvolvedor = await _desenvolvedor.GetById(id);

            if (desenvolvedor == null)
            {
                return NotFound();
            }

            await _desenvolvedor.Delete(desenvolvedor);

            return desenvolvedor;
        }
    }
}