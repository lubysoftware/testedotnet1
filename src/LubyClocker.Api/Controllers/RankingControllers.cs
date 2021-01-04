using System.Threading.Tasks;
using LubyClocker.Application.BoundedContexts.Projects.Queries.FindWeekRanking;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LubyClocker.Api.Controllers
{
    [Route("api/v1/ranking")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class RankingController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public RankingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("week")]
        public async Task<IActionResult> FindWeekRanking()
        {
            var result = await _mediator.Send(new FindDevelopersWeekRankingQuery());
            
            return Ok(result);
        }
    }
}
