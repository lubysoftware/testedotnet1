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
            return View(await _context.RegistrosDeHoras.ToListAsync());
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
            if (registroDeHoras == null)
            {
                return NotFound();
            }

            return View(registroDeHoras);
        }

        // GET: RegistroDeHoras/Create
        public IActionResult Create()
        {
            ViewBag.Desenvolvedor = _context.Desenvolvedores.Select(c => new SelectListItem() { Text = c.Nome.ToUpper(), Value = c.Nome }).ToList();
            ViewBag.Projetos = _context.Projetos.Select(c => new SelectListItem() { Text = c.NomeDoProjeto.ToUpper(), Value = c.NomeDoProjeto }).ToList();
            return View();
        }

        // POST: RegistroDeHoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataInicio,DataFim,TotalPausa,TotalHoras")] RegistroDeHoras registroDeHoras)
        {
            if (ModelState.IsValid)
            {
                registroDeHoras.CalculaTotalHoras();

                _context.Add(registroDeHoras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataInicio,DataFim,HoraInicio,TotalPausa,HoraFim,TotalHoras")] RegistroDeHoras registroDeHoras)
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