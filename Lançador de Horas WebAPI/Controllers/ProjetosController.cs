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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoService _projetoService;

        public ProjetosController(ProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        // GET: api/Projetos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> GetProjetos()
        {
            return await _projetoService.Get();
        }

        // GET: api/Projetos/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Projeto>> PostProjeto(Projeto projeto)
        {
            await _projetoService.Create(projeto);

            return CreatedAtAction("GetDesenvolvedor", new { id = projeto.Id }, projeto);
        }

        // DELETE: api/Projetos/5
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