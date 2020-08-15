using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Services;
using System.Security.Cryptography;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    public class RegistroDeHorasController : Controller
    {
        private readonly RegistroDeHorasService _registroDeHorasService;
        private readonly ProjetoService _projetoService;
        private readonly DesenvolvedorService _desenvolvedorService;

        public RegistroDeHorasController(RegistroDeHorasService registroDeHorasService, ProjetoService projetoService, DesenvolvedorService desenvolvedorService)
        {
            _registroDeHorasService = registroDeHorasService;
            _projetoService = projetoService;
            _desenvolvedorService = desenvolvedorService;
        }

        #region Controle da View

        // GET: RegistroDeHoras
        public async Task<IActionResult> Index()
        {
            var registroDeHoras = await _registroDeHorasService.Get();

            foreach (var item in registroDeHoras)
            {
                item.Projeto = await _projetoService.GetById(item.ProjetoId);
                item.Desenvolvedor = await _desenvolvedorService.GetById(item.DesenvolvedorId);
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

            var registroDeHoras = await _registroDeHorasService.GetById(id);

            if (registroDeHoras == null)
            {
                return NotFound();
            }
            else
            {
                registroDeHoras.Projeto = await _projetoService.GetById(registroDeHoras.ProjetoId);
                registroDeHoras.Desenvolvedor = await _desenvolvedorService.GetById(registroDeHoras.DesenvolvedorId);
            }

            return View(registroDeHoras);
        }

        // GET: RegistroDeHoras/Create
        public async Task<IActionResult> Create()
        {
            ViewData["DesenvolvedorId"] = new SelectList(await _desenvolvedorService.Get(), "Id", "Nome");
            ViewData["ProjetoId"] = new SelectList(await _projetoService.Get(), "Id", "NomeDoProjeto");
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
                await _registroDeHorasService.Create(registroDeHoras);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DesenvolvedorId"] = new SelectList(await _desenvolvedorService.Get(), "Id", "Nome", registroDeHoras.DesenvolvedorId);
            ViewData["ProjetoId"] = new SelectList(await _projetoService.Get(), "Id", "NomeDoProjeto", registroDeHoras.ProjetoId);

            return View(registroDeHoras);
        }

        // GET: RegistroDeHoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroDeHoras = await _registroDeHorasService.GetById(id);

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
            if (id != registroDeHoras.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _registroDeHorasService.Update(id, registroDeHoras) == null)
                {
                    return NotFound();
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

            var registroDeHoras = await _registroDeHorasService.GetById(id);

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
            var registroDeHoras = await _registroDeHorasService.GetById(id);

            if (registroDeHoras == null)
            {
                return NotFound();
            }

            await _registroDeHorasService.Delete(registroDeHoras);

            await _registroDeHorasService.Delete(registroDeHoras);
            return RedirectToAction(nameof(Index));
        }

        #endregion Controle da View

        #region Controle da API com Json

        // GET: api/RegistrosDeHoras
        [HttpGet]
        [Route("api/[controller]")]
        public async Task<ActionResult<IEnumerable<RegistroDeHoras>>> GetRegistrosDeHoras()
        {
            return await _registroDeHorasService.Get();
        }

        // GET: api/RegistrosDeHoras/5
        [Route("api/[controller]/{id}")]
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
        [Route("api/[controller]/{id}")]
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
        [Route("api/[controller]")]
        [HttpPost]
        public async Task<ActionResult<RegistroDeHoras>> PostRegistroDeHoras(RegistroDeHoras registroDeHoras)
        {
            await _registroDeHorasService.Create(registroDeHoras);

            return CreatedAtAction("GetDesenvolvedor", new { id = registroDeHoras.Id }, registroDeHoras);
        }

        // DELETE: api/RegistrosDeHoras/5
        [Route("api/[controller]/{id}")]
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

        #endregion Controle da API com Json
    }
}