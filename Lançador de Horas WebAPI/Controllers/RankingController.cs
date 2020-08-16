using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    /// <summary>
    /// API CRUD para Ranking
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RankingController : Controller
    {
        private readonly RankingService _ranking;

        /// <summary>
        ///
        /// </summary>
        /// <param name="rankingService">Serviço de CRUD ao banco</param>
        public RankingController(RankingService rankingService)
        {
            _ranking = rankingService;
        }

        // GET: api/Ranking
        /// <summary>
        /// Obtém os 5 desenvolvedores da semana com maior média de horas trabalhadas.
        /// </summary>
        /// <returns>Retorna uma lista com os 5 desenvolvedores da semana com maior média de horas trabalhadas.</returns>
        /// <response code="401">Token de acesso não autorizado</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetRegistrosDeHoras()
        {
            return await _ranking.GetRanking();
        }
    }
}