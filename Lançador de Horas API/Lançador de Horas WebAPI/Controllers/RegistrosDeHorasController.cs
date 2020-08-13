using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lançador_de_Horas_WebAPI.Models;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosDeHorasController : ControllerBase
    {
        private readonly LancadorContext _context;

        public RegistrosDeHorasController(LancadorContext context)
        {
            _context = context;
        }

        // GET: api/RegistrosDeHoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroDeHoras>>> GetRegistrosDeHoras()
        {
            return await _context.RegistrosDeHoras.ToListAsync();
        }

        // GET: api/RegistrosDeHoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistroDeHoras>> GetRegistroDeHoras(int id)
        {
            var registroDeHoras = await _context.RegistrosDeHoras.FindAsync(id);

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
            if (id != registroDeHoras.ID)
            {
                return BadRequest();
            }

            _context.Entry(registroDeHoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistroDeHorasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/RegistrosDeHoras
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RegistroDeHoras>> PostRegistroDeHoras(RegistroDeHoras registroDeHoras)
        {
            _context.RegistrosDeHoras.Add(registroDeHoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroDeHoras", new { id = registroDeHoras.ID }, registroDeHoras);
        }

        // DELETE: api/RegistrosDeHoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RegistroDeHoras>> DeleteRegistroDeHoras(int id)
        {
            var registroDeHoras = await _context.RegistrosDeHoras.FindAsync(id);
            if (registroDeHoras == null)
            {
                return NotFound();
            }

            _context.RegistrosDeHoras.Remove(registroDeHoras);
            await _context.SaveChangesAsync();

            return registroDeHoras;
        }

        private bool RegistroDeHorasExists(int id)
        {
            return _context.RegistrosDeHoras.Any(e => e.ID == id);
        }
    }
}
