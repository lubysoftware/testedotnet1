using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Handlers;

namespace TesteLuby.MainStartup.Controllers
{
    /// <summary>
    /// Controller de horas trabalhadas
    /// </summary>
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    //[Authorize]

    public class BusinessHourController : ControllerBase
    {
        private readonly BusinessHourHandler _handler;
        private readonly IAppSettings _settings;

        /// <summary>
        /// Construtor controller hora trabalhada
        /// </summary>
        /// <param name="handler">Servico de acesso aos Dados</param>
        /// <param name="settings">Configurações Gerais do sistema</param>
        public BusinessHourController(BusinessHourHandler handler, IAppSettings settings)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <summary>
        /// Seleciona ranking de horas trabalhadas por desenvolvedor
        /// </summary>
        /// <returns>Lista o ranking horas trabalhadas</returns>
        [HttpPost("ranking")]
        public async Task<IActionResult> GetRankingBusinessHourByDeveloper()
        {
            var ranking = await _handler.GetRankingBusinessHourByDeveloper();
            if (ranking.Success)
            {
                return Ok(ranking);
            }
            else
            {
                return StatusCode(500, ranking);
            }
        }
    }
}
