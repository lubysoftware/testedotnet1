using Luby.Models;
using Luby.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luby.Controllers
{
    [Produces("application/json")]
    [Route("api/projeto")]
    public class ProjetoController : BaseController
    {
        private readonly Context _context;
        private IConfiguration _config;
        IHttpContextAccessor accessor;
        private readonly IHostingEnvironment environment;
        ProjetoRepositorio _projetoRepositorio;

        public ProjetoController(IConfiguration config, Context context, IHttpContextAccessor accessor, IHostingEnvironment environment) : base(config, context, accessor)
        {
            _config = config;
            _context = context;
            _projetoRepositorio = new ProjetoRepositorio(_context);
            this.accessor = accessor;
            this.environment = environment;
        }

        [Authorize, HttpPost]
        public async Task<IActionResult> Post([FromBody] Projeto model)
        {
            try
            {
                if (_projetoRepositorio.FindBy(p => p.Nome == model.Nome).Count() > 0)
                    return ReturnBadRequest("Projeto", "Projeto já cadastrado");



                await _projetoRepositorio.AddAndSaveAsync(model);


                return Ok(model);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Authorize, HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Projeto> list = _projetoRepositorio.GetAll().ToList();

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Authorize, HttpGet("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                Projeto projeto = _projetoRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (projeto == null)
                {
                    return BadRequest("Projeto não encontrado.");
                }

                return Ok(projeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [Authorize, HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromBody] Projeto projeto, int id)
        {
            try
            {
                Projeto busca = _projetoRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (busca == null)
                {
                    return BadRequest("Projeto não encontrado.");
                }

                busca.Nome = projeto.Nome;

                await _projetoRepositorio.EditAndSaveAsync(busca);

                return Ok(busca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Authorize, HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                Projeto busca = _projetoRepositorio.FindBy(p => p.Id == id).FirstOrDefault();

                if (busca == null)
                {
                    return BadRequest("Projeto não encontrado.");
                }

                _projetoRepositorio.Delete(busca);

                return Ok("Projeto apagado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
