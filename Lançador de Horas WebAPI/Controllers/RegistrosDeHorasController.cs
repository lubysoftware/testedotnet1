using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    /// <summary>
    /// API CRUD para Registro de horas
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegistrosDeHorasController : ControllerBase
    {
        private readonly RegistroDeHorasService _registroDeHorasService;

        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="registroDeHorasService">Serviço de CRUD ao banco</param>
        public RegistrosDeHorasController(RegistroDeHorasService registroDeHorasService)
        {
            _registroDeHorasService = registroDeHorasService;
        }

        // GET: api/RegistrosDeHoras
        /// <summary>
        /// Obtém todos os registros de horas
        /// </summary>
        /// <returns>A lista de registros de horas</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroDeHoras>>> GetRegistrosDeHoras()
        {
            return await _registroDeHorasService.Get();
        }

        // GET: api/RegistrosDeHoras/5
        /// <summary>
        /// Obtém um registro de hora pelo Id
        /// </summary>
        /// <param name="id">Id do registro de hora</param>
        /// <returns>O registro de hora</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroDeHoras>> GetRegistroDeHoras(int id)
        {
            var registroDeHoras = await _registroDeHorasService.GetById(id);

            if (registroDeHoras == null)
            {
                return NotFound();
            }

            return registroDeHoras;
        }

        // PUT: api/RegistrosDeHoras/5
        /// <summary>
        /// Atualiza um registro de hora
        /// </summary>
        /// <param name="id">Id do registro de hora a ser alterado</param>
        /// <param name="registroDeHoras">Objeto com as alterações</param>
        /// <returns>O registro de hora criado</returns>
        /// /// <response code="201">Retorna o novo registro de hora atualizado</response>
        /// <response code="204">Se a atualização for bem sucedida</response>
        /// <response code="400">Se o registro de hora for nulo</response>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistroDeHoras(int id, RegistroDeHoras registroDeHoras)
        {
            if (id != registroDeHoras.Id)
            {
                return BadRequest();
            }

            if (await _registroDeHorasService.Update(id, registroDeHoras) == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/RegistrosDeHoras
        /// <summary>
        /// Insere um registro de hora
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST
        ///     {
        ///        "dataInicio": "2020-08-15T22:58:00.147Z",
        ///        "dataFim": "2020-08-15T22:58:00.147Z",
        ///        "totalHoras": "0.08:20:00",
        ///        "desenvolvedorId": 1,
        ///        "projetoId": 1,
        ///     }
        ///
        /// </remarks>
        /// <param name="registroDeHoras">Objeto registro de horas a ser inserido</param>
        /// <returns>O registro de hora criado</returns>
        /// /// <response code="201">Retorna o novo registro de hora criado</response>
        /// <response code="400">Se o registro de hora for nulo</response>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpPost]
        public async Task<ActionResult<RegistroDeHoras>> PostRegistroDeHoras(RegistroDeHoras registroDeHoras)
        {
            await _registroDeHorasService.Create(registroDeHoras);

            return CreatedAtAction("GetDesenvolvedor", new { id = registroDeHoras.Id }, registroDeHoras);
        }

        // DELETE: api/RegistrosDeHoras/5
        /// <summary>
        /// Deleta um registro de hora
        /// </summary>
        /// <param name="id">Id do registro de hora a ser alterado</param>
        /// <returns>Retorna o registro de hora deletado</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroDeHoras>> DeleteRegistroDeHoras(int id)
        {
            var registroDeHoras = await _registroDeHorasService.GetById(id);

            if (registroDeHoras == null)
            {
                return NotFound();
            }

            await _registroDeHorasService.Delete(registroDeHoras);

            return registroDeHoras;
        }
    }
}