using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegistrosDeHorasController : ControllerBase
    {
        private readonly RegistroDeHorasService _registroDeHorasService;

        public RegistrosDeHorasController(RegistroDeHorasService registroDeHorasService)
        {
            _registroDeHorasService = registroDeHorasService;
        }

        // GET: api/RegistrosDeHoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroDeHoras>>> GetRegistrosDeHoras()
        {
            return await _registroDeHorasService.Get();
        }

        // GET: api/RegistrosDeHoras/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegistroDeHoras>> PostRegistroDeHoras(RegistroDeHoras registroDeHoras)
        {
            await _registroDeHorasService.Create(registroDeHoras);

            return CreatedAtAction("GetDesenvolvedor", new { id = registroDeHoras.Id }, registroDeHoras);
        }

        // DELETE: api/RegistrosDeHoras/5
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