using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;
using TesteLuby.Domain.CommandsParameters;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Handlers;

namespace TesteLuby.MainStartup.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class ProjectController : ControllerBase
    {
        private readonly ProjectHandler _handler;
        private readonly IAppSettings _settings;

        /// <summary>
        /// Construtor controller Projetos
        /// </summary>
        /// <param name="handler">Servico de acesso aos Dados</param>
        /// <param name="settings">Configurações Gerais do sistema</param>
        public ProjectController(ProjectHandler handler, IAppSettings settings)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <summary>
        /// Busca todos os projetos
        /// </summary>
        /// <returns>Lista de projetos (JSON)</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _handler.Get();
            if (users.Success)
            {
                return Ok(users);
            }
            else
            {
                return StatusCode(500, users);
            }
        }


        /// <summary>
        /// Adiciona um novo projeto
        /// </summary>
        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> PostUser(CreateProjectCommand project)
        {
            var project_ = await _handler.CreateProject(project);
            if (project_.Success)
            {
                return Ok(project_);
            }
            else
            {
                switch (project_.Status)
                {
                    case 400:
                        return BadRequest(project_);
                    case 406:
                        return BadRequest(project_);
                    case 500:
                        return StatusCode(500, project_);
                    default:
                        return BadRequest(project_);
                }
            }
        }

        /// <summary>
        /// Altera informações do projeto
        /// </summary>
        /// <param name="update"></param>
        /// <returns>Altera informações do projeto</returns>
        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateProject(UpdateProjectCommand update)
        {
            var project = await _handler.UpdateProject(update);
            if (project.Success)
            {
                return Ok(project);
            }
            else
            {
                switch (project.Status)
                {
                    case 400:
                        return BadRequest(project);
                    case 406:
                        return BadRequest(project);
                    case 500:
                        return StatusCode(500, project);
                    default:
                        return BadRequest(project);
                }
            }
        }

        /// <summary>
        /// Remove um projeto
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProjectCommand projeto)
        {
            var delete = await _handler.DeleteProject(projeto);
            if (delete.Success)
            {
                return Ok(delete);
            }
            else
            {
                switch (delete.Status)
                {
                    case 400:
                        return BadRequest(delete);
                    case 404:
                        return NotFound(delete);
                    case 500:
                        return StatusCode(500, delete);
                    default:
                        return BadRequest(delete);
                }
            }
        }
    }
}
