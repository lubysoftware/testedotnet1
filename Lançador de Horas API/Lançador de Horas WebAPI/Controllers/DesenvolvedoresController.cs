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
    public class DesenvolvedoresController : ControllerBase
    {
        private readonly LancadorContext _context;

        public DesenvolvedoresController(LancadorContext context)
        {
            _context = context;
        }

        // GET: api/Desenvolvedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desenvolvedor>>> GetDesenvolvedores()
        {
            return await _context.Desenvolvedores.ToListAsync();
        }

        // GET: api/Desenvolvedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Desenvolvedor>> GetDesenvolvedor(int id)
        {
            var desenvolvedor = await _context.Desenvolvedores.FindAsync(id);

            if (desenvolvedor == null)
            {
                return NotFound();
            }

            return desenvolvedor;
        }

        // PUT: api/Desenvolvedores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDesenvolvedor(int id, Desenvolvedor desenvolvedor)
        {
            if (id != desenvolvedor.ID)
            {
                return BadRequest();
            }

            _context.Entry(desenvolvedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DesenvolvedorExists(id))
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

        // POST: api/Desenvolvedores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Desenvolvedor>> PostDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            _context.Desenvolvedores.Add(desenvolvedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDesenvolvedor", new { id = desenvolvedor.ID }, desenvolvedor);
        }

        // DELETE: api/Desenvolvedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Desenvolvedor>> DeleteDesenvolvedor(int id)
        {
            var desenvolvedor = await _context.Desenvolvedores.FindAsync(id);
            if (desenvolvedor == null)
            {
                return NotFound();
            }

            _context.Desenvolvedores.Remove(desenvolvedor);
            await _context.SaveChangesAsync();

            return desenvolvedor;
        }

        private bool DesenvolvedorExists(int id)
        {
            return _context.Desenvolvedores.Any(e => e.ID == id);
        }
    }
}
