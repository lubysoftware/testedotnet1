using Aplicacao.DTO.DTO;
using Aplicacao.Principal.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/desenvolvedores/registrohoras/ranking")]
    public class RegistroHoraRankingController : ControllerBase
    {        
        private readonly IAppServicoRegistroHorasRanking _appServicoRegistroRanking;

        public RegistroHoraRankingController(IAppServicoRegistroHorasRanking appServicoRegistroRanking)
        {            
            _appServicoRegistroRanking = appServicoRegistroRanking;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<RegistroHoraRankingDTO>> GetRanking()
        {
            try
            {
                return await _appServicoRegistroRanking.GetSemanaComMaisHorasTrabalhadas(5);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu uma falha inesperada. Entre em contato com o suporte técnico.");
            }
        }
    }
}
