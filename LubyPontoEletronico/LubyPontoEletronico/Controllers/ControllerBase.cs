using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace LubyPontoEletronico.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDTO"></typeparam>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ControllerBase<TEntity, TEntityDTO> : Controller
        where TEntity : class
        where TEntityDTO : class
    {
        /// <summary>
        /// 
        /// </summary>
        readonly protected IApplicationBase<TEntity, TEntityDTO> _app;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public ControllerBase(IApplicationBase<TEntity, TEntityDTO> app)
        {
            _app = app;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _app.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _app.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] TEntityDTO data)
        {
            try
            {
                if (data == null)
                {
                    throw new Exception("Dados de entradas incorretos.");
                }

                _app.Create(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update([FromBody] TEntityDTO data)
        {
            try
            {
                if (data == null)
                {
                    throw new Exception("Dados de entradas incorretos.");
                }

                _app.Update(data);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _app.Remove(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
