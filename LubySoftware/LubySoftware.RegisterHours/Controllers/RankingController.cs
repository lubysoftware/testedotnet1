using LubySoftware.Domain.Models;
using LubySoftware.Domain.Repositories;
using LubySoftware.RegisterHours.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LubySoftware.RegisterHours.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RankingController : ControllerBase
    {
        readonly RankingService RankingService;

        public RankingController(
            IRegisterHoursRepository registerHoursRepository,
            IPersonRepository personRepository
        )
        {
            RankingService = new RankingService(
                registerHoursRepository,
                personRepository);
        }

        [HttpGet]
        public async Task<IEnumerable<PersonModel>> Get()
        {
            return await RankingService.FindTopFiveDevelopers();
        }
    }
}
