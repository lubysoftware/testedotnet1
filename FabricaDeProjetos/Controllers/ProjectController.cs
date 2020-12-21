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
    public class ProjectController : FabricaDeProjetosControllerBase
    {
        private readonly IProjectCore _core;

        public ProjectController(IProjectCore core, IConfiguration configuration) : base(configuration)
        {
            _core = core;
        }

        internal override void CreateCoreConnections()
        {
            _core.CreateConnection(_Server);
        }

        [HttpGet]
        [Route("GetProjectsById/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetProjectsById(int id)
        {
            var ret = _core.GetProjectsById(id);
            return Ok(ret);
        }

        [HttpGet]
        [Route("GetProjectsByIdDeveloper/{id:int}")]
        [AllowAnonymous]
        public IActionResult GetProjectsByIdDeveloper(int id)
        {
            var ret = _core.GetProjectsByIdDeveloper(id);
            return Ok(ret);
        }

        [HttpPost]
        [Route("AddProject")]
        [AllowAnonymous]
        public IActionResult AddProject([FromBody] ProjectViewModel developer)
        {
            try
            {
                object ret = _core.AddProject(developer);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar o cliente.");
            }
        }

        [HttpPut]
        [Route("UpdateProject")]
        [AllowAnonymous]
        public IActionResult UpdateProject([FromBody] ProjectViewModel developer)
        {
            try
            {
                object ret = _core.UpdateProject(developer);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível modificar o cliente.");
            }
        }

        [HttpDelete]
        [Route("DeleteProject")]
        [AllowAnonymous]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                object ret = _core.DeleteProject(id);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível deletar  o cliente.");
            }
        }
    }
}
