using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FabricaDeProjetos.Domain.Entities;
using Core.ViewModels;

namespace FabricaDeProjetos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectCore _core;

        public ProjectController(IProjectCore core)
        {
            _core = core;
        }

        [HttpGet]
        [Authorize]
        [Route("GetProjectsById")]
        public IEnumerable<Project> GetProjectsById(int id)
        {
            return _core.GetProjectsById(id);
        }

        [HttpGet]
        [Authorize]
        [Route("GetProjectsByIdDeveloper")]
        public IEnumerable<Project> GetProjectsByIdDeveloper(int idDeveloper)
        {
            return _core.GetProjectsByIdDeveloper(idDeveloper);
        }

        [HttpGet]
        [Authorize]
        [Route("GetProjectsActive")]
        public IEnumerable<Project> GetProjectsActive()
        {
            return _core.GetProjectsActive();
        }

        [HttpGet]
        [Authorize]
        [Route("GetProjectsNoActive")]
        public IEnumerable<Project> GetProjectsNoActive()
        {
            return _core.GetProjectsNoActive();
        }

        [HttpPost]
        [Authorize]
        [Route("AddProject")]
        public IActionResult AddProject([FromBody] ProjectViewModel project)
        {
            try
            {
                object ret = _core.AddProject(project);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível cadastrar o projeto.");
            }
        }

        [HttpPut]
        [Authorize]
        [Route("UpdateProject")]
        public IActionResult UpdateProject([FromBody] ProjectViewModel project)
        {
            try
            {
                object ret = _core.UpdateProject(project);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível modificar o projeto.");
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("DeleteProject")]
        public IActionResult DeleteProject([FromBody] ProjectViewModel project)
        {
            try
            {
                object ret = _core.DeleteProject(project);
                return Created("Get", ret);
            }
            catch (Exception)
            {
                return BadRequest("Não foi possível deletar o projeto.");
            }
        }
    }
}
