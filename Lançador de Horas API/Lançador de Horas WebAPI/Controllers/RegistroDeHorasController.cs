using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lançador_de_Horas_WebAPI.Models;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    public class RegistroDeHorasController : Controller
    {
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

        private bool RegistroDeHorasExists(int id)
        {
            return _context.RegistrosDeHoras.Any(e => e.ID == id);
        }
    }
}