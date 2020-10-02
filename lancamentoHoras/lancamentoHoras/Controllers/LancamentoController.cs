using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lancamentoHoras.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lancamentoHoras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<string> Post([FromForm] DateTime inicio, [FromForm] DateTime fim, [FromForm] int desenvolvedor)
        {
            return await DBQueries.NewHourEntry(inicio, fim, desenvolvedor);
        }

        [HttpGet]
        [Route("ranking")]
        public async Task<string> Get()
        {
            return await DBQueries.GetRanking();
        }
    }
}