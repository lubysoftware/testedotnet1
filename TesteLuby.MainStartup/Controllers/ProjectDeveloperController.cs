using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Handlers;

namespace TesteLuby.MainStartup.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]

    public class ProjectDeveloperController : ControllerBase
    {
        private readonly ProjectDeveloperHandler _handler;
        private readonly IAppSettings _settings;

        /// <summary>
        /// Construtor controller ProjetoDeveloper
        /// </summary>
        /// <param name="handler">Servico de acesso aos Dados</param>
        /// <param name="settings">Configurações Gerais do sistema</param>
        public ProjectDeveloperController(ProjectDeveloperHandler handler, IAppSettings settings)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <summary>
        /// Busca todos os projetodeveloper
        /// </summary>
        /// <returns>Lista de projetodeveloper (JSON)</returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var projectdeveloper = await _handler.Get();
            if (projectdeveloper.Success)
            {
                return Ok(projectdeveloper);
            }
            else
            {
                return StatusCode(500, projectdeveloper);
            }
        }
    }
}
