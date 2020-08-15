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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Desenvolvedor>>> GetDesenvolvedores()
        {
            return await _desenvolvedor.Get();
        }

        // GET: api/Desenvolvedores/5
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Desenvolvedor>> PostDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            await _desenvolvedor.Create(desenvolvedor);

            return CreatedAtAction("GetDesenvolvedor", new { id = desenvolvedor.Id }, desenvolvedor);
        }

        // DELETE: api/Desenvolvedores/5
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