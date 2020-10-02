using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;
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
        [HttpPost("all")]
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
    }
}
