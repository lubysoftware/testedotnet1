using ApiLuby.Business.Entities;
using ApiLuby.Business.Entities.Repositories;
using ApiLuby.Infrastructure.Data;
using ApiLuby.Infrastructure.Data.Repositories;
using ApiLuby.Models.BankOfHours;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiLuby.Controllers
{
    [Route("api/v1/bankofhours")]
    [ApiController]
    [Authorize]
    public class BankOfHoursController : ControllerBase
    {
        private readonly IBankOfHoursRepository _banfOfHoursRespository;

        public BankOfHoursController(IBankOfHoursRepository bankOfHoursRepository)
        {
            _banfOfHoursRespository = bankOfHoursRepository;
        }
        /// <summary>
        /// Este serviço permite lançar horas ativas para um desenvolvedor.
        /// </summary>
        /// <returns>Retorna status ok, dados do developer e o token em caso de sucesso</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso no lançamento de horas")]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpPost]
        [Route("a")]
        public async Task<IActionResult> Post(BankOfHoursViewModelInput bankOfHoursViewModelInput)
        {
            BankOfHours bankOfHours = new BankOfHours();
            bankOfHours.EntryDate = bankOfHoursViewModelInput.EntryDate;
            bankOfHours.FinalDate = bankOfHoursViewModelInput.FinalDate;
            bankOfHours.TotalHours = bankOfHoursViewModelInput.TotalHours; 
            var developerCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            bankOfHours.CodigoDeveloper = developerCode;
            _banfOfHoursRespository.Add(bankOfHours);
            _banfOfHoursRespository.Commit();
            return Created("", bankOfHoursViewModelInput);
        }
        /// <summary>
        /// Este serviço permite obter todas as horas ativas do desenvolvedor.
        /// </summary>
        /// <returns>Retorna status ok </returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter registro de horas")]
        [SwaggerResponse(statusCode: 401, description: "Não Autorizado")]
        [HttpGet]
        [Route("")]

        public async Task<IActionResult> Get()
        {

            var developerCode = int.Parse(User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var hours = _banfOfHoursRespository.GetPerDeveloper(developerCode)
                .Select(s => new BankOfHoursViewModelOutput()
                {
                    EntryDate = s.EntryDate,
                    FinalDate = s.FinalDate,
                    TotalHours = s.TotalHours,
                    Login = s.Developer.Login

                });
            return Ok(hours);

        }
       
    }
}



