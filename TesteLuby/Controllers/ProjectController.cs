using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteLuby.Interfaces;
using TesteLuby.Interfaces.DTO;

namespace TesteLuby.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<ProjectDTO> Get(int id)
        {
            try
            {
                var data = _projectService.Get(id);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("getbyname/{name}")]
        [HttpGet]
        public ActionResult<IEnumerable<ProjectDTO>> GetByName(string name)
        {
            try
            {
                var data = _projectService.GetByName(name);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("save")]
        [HttpPost]
        public ActionResult Save(ProjectDTO projectDTO)
        {
            try
            {
                if (_projectService.Insert(projectDTO))
                    return Ok("Salvo com sucesso");
                else
                    return BadRequest("Nao foi possivel salvar o Projeto. Por favor, verifique os campos.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("edit/{id}")]
        [HttpPut]
        public ActionResult Edit(ProjectDTO projectDTO, int id)
        {
            try
            {
                if (_projectService.Update(projectDTO, id))
                    return Ok("Atualizado com Sucesso");
                else
                    return BadRequest("Nao foi possivel salvar o Projeto. Por favor, verifique os campos.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
