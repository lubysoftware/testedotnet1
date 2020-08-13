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

namespace Lançador_de_Horas_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly LancadorContext _context;

        public RankingController(LancadorContext context)
        {
            _context = context;
        }

        // GET: api/Ranking
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistroDeHoras>>> GetRegistrosDeHoras()
        {
            return await _context.RegistrosDeHoras.Where(x => DateTime.Now >= x.DataInicio.AddDays(-7))
                 .OrderByDescending(x => x.TotalHoras / 7).SkipLast(5).ToListAsync();
        }
    }
}