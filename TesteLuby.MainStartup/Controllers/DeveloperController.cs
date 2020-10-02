using TesteLuby.MainStartUp.Utilities;
using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteLuby.Domain.CommandsParameters;

namespace TesteLuby.MainStartUp.Controllers
{
    /// <summary>
    /// Controller desenvolvedor
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
 
    public class DeveloperController : ControllerBase
    {
        private readonly DeveloperHandler _handler;
        private readonly IAppSettings _settings;

        /// <summary>
        /// Construtor controller desenvolvedor
        /// </summary>
        /// <param name="handler">Servico de acesso aos Dados</param>
        /// <param name="settings">Configurações Gerais do sistema</param>
        public DeveloperController(DeveloperHandler handler, IAppSettings settings)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

    }
}
