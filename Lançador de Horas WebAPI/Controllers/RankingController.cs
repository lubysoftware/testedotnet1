using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lançador_de_Horas_WebAPI.Models;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.WindowsRuntime;
using Lançador_de_Horas_WebAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace Lançador_de_Horas_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class RankingController : Controller
    {
        private readonly RankingService _ranking;

        public RankingController(RankingService rankingService)
        {
            _ranking = rankingService;
        }

        // GET: api/Ranking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetRegistrosDeHoras()
        {
            return await _ranking.GetRanking();
        }
    }
}