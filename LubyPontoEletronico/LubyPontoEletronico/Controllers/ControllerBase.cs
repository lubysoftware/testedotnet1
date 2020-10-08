using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LubyPontoEletronico.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ControllerBase<TEntity, TEntityDTO> : Controller
        where TEntity : class
        where TEntityDTO : class
    {
        readonly protected IApplicationBase<TEntity, TEntityDTO> _app;
        public ControllerBase(IApplicationBase<TEntity, TEntityDTO> app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Listar()
        {
            try
            {
                var restaurantes = _app.GetAll();
                return new OkObjectResult(restaurantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult SelecionarPorId(int id)
        {
            try
            {
                var restaurantes = _app.GetById(id);
                return new OkObjectResult(restaurantes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Incluir([FromBody] TEntityDTO dado)
        {
            try
            {
                _app.Create(dado);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] TEntityDTO dado)
        {
            try
            {
                _app.Update(dado);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _app.Remove(id);
                return new OkObjectResult(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
