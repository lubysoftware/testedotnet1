using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLuby.Models;
using TesteLuby.Repositorios;

namespace TesteLuby.Controllers
{
    [Produces("application/json")]
    [Route("api/desenvolvedor")]
    public class DesenvolvedorController : ControllerBase
    {


        private readonly Context _context;
        private IConfiguration _config;
        private readonly IHostingEnvironment environment;
        DesenvolvedorRepositorio _desenvolvedorRepositorio;

        public DesenvolvedorController(IConfiguration config, Context context,  IHostingEnvironment environment)
        {
            _config = config;
            _context = context;
            _desenvolvedorRepositorio = new DesenvolvedorRepositorio(_context);
            this.environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Desenvolvedor> list = _desenvolvedorRepositorio.GetAll().ToList();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                Desenvolvedor desenvolvedor = _desenvolvedorRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (desenvolvedor == null)
                {
                    return BadRequest("Desenvolvedor não encontrado.");
                }

                return Ok(desenvolvedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Desenvolvedor desenvolvedor)
        {
            try
            {
                Desenvolvedor aux = _desenvolvedorRepositorio.FindBy(p => p.Email.Equals(desenvolvedor.Email)).FirstOrDefault();

                if(aux != null)
                {
                    return BadRequest("Email já cadastrado.");
                }

                await _desenvolvedorRepositorio.AddAndSaveAsync(desenvolvedor);
                return Ok(desenvolvedor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] Desenvolvedor desenvolvedor, int id)
        {
            try
            {
                Desenvolvedor busca = _desenvolvedorRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if(busca == null)
                {
                    return BadRequest("Desenvolvedor não encontrado.");
                }

                busca.Nome = desenvolvedor.Nome;
                busca.Email = desenvolvedor.Email;

                await _desenvolvedorRepositorio.EditAndSaveAsync(busca);

                return Ok(busca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                Desenvolvedor busca = _desenvolvedorRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (busca == null)
                {
                    return BadRequest("Desenvolvedor não encontrado.");
                }

                _desenvolvedorRepositorio.Delete(busca);

                return Ok("Desenvolvedor apagado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
