using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Context;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    public class RegistroDeHorasController : Controller
    {
        #region Controle da View

        private readonly LancadorContext _context;

        public RegistroDeHorasController(LancadorContext context)
        {
            _context = context;
        }

        // GET: RegistroDeHoras
        public async Task<IActionResult> Index()
        {
            var registroDeHoras = await _context.RegistrosDeHoras.ToListAsync();

            foreach (var item in registroDeHoras)
            {
                item.Projeto = await _context.Projetos.Where(x => x.Id == item.ProjetoId).FirstOrDefaultAsync();
                item.Desenvolvedor = await _context.Desenvolvedores.Where(x => x.Id == item.DesenvolvedorId).FirstOrDefaultAsync();
            }

            return View(registroDeHoras);
        }

        // GET: RegistroDeHoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDeHoras = await _context.RegistrosDeHoras
                .FirstOrDefaultAsync(m => m.ID == id);
            registroDeHoras.Projeto = await _context.Projetos.Where(x => x.Id == registroDeHoras.ProjetoId).FirstOrDefaultAsync();
            registroDeHoras.Desenvolvedor = await _context.Desenvolvedores.Where(x => x.Id == registroDeHoras.DesenvolvedorId).FirstOrDefaultAsync();
            if (registroDeHoras == null)
            {
                return NotFound();
            }

            return View(registroDeHoras);
        }

        // GET: RegistroDeHoras/Create
        public IActionResult Create()
        {
            ViewData["DesenvolvedorId"] = new SelectList(_context.Desenvolvedores, "Id", "Nome");
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "NomeDoProjeto");
            return View();
        }

        // POST: RegistroDeHoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataInicio,DataFim,TotalHoras,DesenvolvedorId,ProjetoId")] RegistroDeHoras registroDeHoras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroDeHoras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesenvolvedorId"] = new SelectList(_context.Desenvolvedores, "Id", "Nome", registroDeHoras.DesenvolvedorId);
            ViewData["ProjetoId"] = new SelectList(_context.Projetos, "Id", "NomeDoProjeto", registroDeHoras.ProjetoId);

            return View(registroDeHoras);
        }

        // GET: RegistroDeHoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDeHoras = await _context.RegistrosDeHoras.FindAsync(id);
            if (registroDeHoras == null)
            {
                return NotFound();
            }
            return View(registroDeHoras);
        }

        // POST: RegistroDeHoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataInicio,DataFim,TotalHoras,DesenvolvedorId,ProjetoId")] RegistroDeHoras registroDeHoras)
        {
            if (id != registroDeHoras.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroDeHoras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroDeHorasExists(registroDeHoras.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registroDeHoras);
        }

        // GET: RegistroDeHoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDeHoras = await _context.RegistrosDeHoras
                .FirstOrDefaultAsync(m => m.ID == id);
            if (registroDeHoras == null)
            {
                return NotFound();
            }

            return View(registroDeHoras);
        }

        // POST: RegistroDeHoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroDeHoras = await _context.RegistrosDeHoras.FindAsync(id);
            _context.RegistrosDeHoras.Remove(registroDeHoras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion Controle da View

        #region Controle da API com Json

        // GET: api/RegistrosDeHoras
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult<IEnumerable<RegistroDeHoras>>> GetRegistrosDeHoras()
        {
            return await _context.RegistrosDeHoras.ToListAsync();
        }

        // GET: api/RegistrosDeHoras/5
        [Route("api/[controller]/{id}")]
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
        [Route("api/[controller]/{id}")]
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
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<ActionResult<RegistroDeHoras>> PostRegistroDeHoras(RegistroDeHoras registroDeHoras)
        {
            _context.RegistrosDeHoras.Add(registroDeHoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistroDeHoras", new { id = registroDeHoras.ID }, registroDeHoras);
        }

        // DELETE: api/RegistrosDeHoras/5
        [Route("api/[controller]/{id}")]
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

        #endregion Controle da API com Json

        private bool RegistroDeHorasExists(int id)
        {
            return _context.RegistrosDeHoras.Any(e => e.ID == id);
        }
    }
}