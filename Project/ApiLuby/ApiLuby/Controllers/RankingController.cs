using ApiLuby.Business.Entities;
using ApiLuby.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLuby.Controllers
{
    [Route("api/v1/RankingHours")]
    [ApiController]
    [Authorize]
    public class RankingController : ControllerBase
    {

        BankOfHoursRepository _service;

        public RankingController()
        {
            _service = new BankOfHoursRepository();
        }
        /// <summary>
        /// Este serviço permite obter o ranking dos desenvolvedores com maior número de horas.
        /// </summary>
        /// <returns>Retorna status ok </returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter registro de horas")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [HttpGet("ranking")]

        public List<BankOfHoursVM> GetRanking(int developerCode)
        {
            return _service.GetTotalHours(developerCode);
        }
    }
}

