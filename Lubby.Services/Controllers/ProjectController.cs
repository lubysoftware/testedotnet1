using Lubby.Domain.Interfaces;
using Lubby.Domain.Root;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lubby.Services.Controllers
{
    [Route("services/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository projectRepository;
        public ProjectController(IProjectRepository projectRepo) => projectRepository = projectRepo;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Project project)
        {
            try
            {
                await projectRepository.Create(project);
                return Created(String.Empty, project);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não realizado");
            }
        }

        [HttpGet]
        [Route("{identifier}")]
        public async Task<IActionResult> Get(string identifier)
        {
            try
            {
                Project project = await projectRepository.Get(identifier);
                return Ok(project);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não localizado");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Project project)
        {
            try
            {
                await projectRepository.Update(project);
                return Accepted();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Ok("Registro não atualizado");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Project> projects = await projectRepository.List();
            return Ok(projects);
        }
    }
}
