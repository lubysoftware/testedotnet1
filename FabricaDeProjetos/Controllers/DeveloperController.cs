using System;
using Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using FabricaDeProjetos.Controllers.Base;
using Core.ViewModels;

namespace FabricaDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : FabricaDeProjetosControllerBase
    {
        private readonly IDeveloperCore _core;

        public DeveloperController(IDeveloperCore core,IConfiguration configuration) : base(configuration)
        {
            _core = core;
        }

        internal override void CreateCoreConnections()
        {
            _core.CreateConnection(_Server);
        }

        [HttpGet]
        [Route("GetDeveloperById/{id:int}")]
        [AllowAnonymous]
        public IActionResult  GetDeveloperById(int id)
        {
            var ret = _core.GetDeveloperById(id);
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetDevelopers")]
        [AllowAnonymous]
        public IActionResult GetDevelopers()
        {
            var ret = _core.GetDevelopers();
            return Ok(ret);
        }

        [HttpPost]
        [Route("AddDeveloper")]
        [AllowAnonymous]
        public IActionResult AddDeveloper([FromBody] DeveloperViewModel developer)
        {
            try
            {
                object ret = _core.AddDeveloper(developer);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar o cliente.");
            }
        }

        [HttpPut]
        [Route("UpdateDeveloper")]
        [AllowAnonymous]
        public IActionResult UpdateDeveloper([FromBody] DeveloperViewModel developer)
        {
            try
            {
                object ret = _core.UpdateDeveloper(developer);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível modificar o cliente.");
            }
        }

        [HttpDelete]
        [Route("DeleteDeveloper")]
        [AllowAnonymous]
        public IActionResult DeleteDeveloper(int id)
        {
            try
            {
                object ret = _core.DeleteDeveloper(id);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível deletar  o cliente.");
            }
        }
    }
}
