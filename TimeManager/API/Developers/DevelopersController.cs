using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TimeManager.API.Developers.TimeReports;
using TimeManager.Application.Developers;
using TimeManager.Application.Developers.ChangeDeveloperDetails;
using TimeManager.Application.Developers.GetDevelopers;
using TimeManager.Application.Developers.GetWeekRanking;
using TimeManager.Application.Developers.RegisterDeveloper;
using TimeManager.Application.Developers.RemoveDeveloper;
using TimeManager.Application.Developers.TimeReports.GetTimeReports;
using TimeManager.Application.Developers.TimeReports.SendTimeReport;

namespace TimeManager.API.Developers
{
    [Route("api/developers")]
    [ApiController]
    public class DevelopersController : Controller
    {
        private readonly IMediator _mediator;

        public DevelopersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all developers.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(DevelopersViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetDevelopersQuery());

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Register a new developer.
        /// </summary>
        /// <param name="request">Name of the developer</param>
        [HttpPost]
        [ProducesResponseType(typeof(DeveloperDto), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> RegisterDeveloper([FromBody] DeveloperDetailsRequest request)
        {
            var response = await _mediator.Send(new RegisterDeveloperCommand(request.Name));

            if (response.IsSuccess)
                return Created(string.Empty, null);

            return BadRequest(response.Errors);
        }

        /// <summary>
        /// Change developer details.
        /// </summary>
        /// <param name="developerId">Developer ID</param>
        /// <param name="request">Name of the developer</param>
        [HttpPut("{developerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeDeveloperDetails([FromRoute] Guid developerId, [FromBody] DeveloperDetailsRequest request)
        {
            var response = await _mediator.Send(new ChangeDeveloperDetailsCommand(developerId, request.Name));

            if (response.IsSuccess)
                return Ok();

            return BadRequest(response.Errors);
        }

        /// <summary>
        /// Remove a developer.
        /// </summary>
        /// <param name="developerId">Developer ID</param>
        [HttpDelete("{developerId}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveDeveloper([FromRoute] Guid developerId)
        {
            var response = await _mediator.Send(new RemoveDeveloperCommand(developerId));

            if (response.IsSuccess)
                return Ok();

            return BadRequest(response.Errors);
        }

        /// <summary>
        /// Send time report to a project.
        /// </summary>
        /// <param name="developerId">Developer Id</param>
        /// <param name="projectId">Project ID</param>
        /// <param name="request">Start and End time</param>
        [HttpPost("{developerId}/project/{projectId}/report")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> SendTimeReport([FromRoute] Guid developerId, [FromRoute] Guid projectId, [FromBody] SendTimeReportRequest request)
        {
            var r = new Random();
            request.StartedAt = DateTime.Now;
            request.EndedAt = request.StartedAt.AddHours(r.Next(1, 8));

            var response = await _mediator.Send(new SendTimeReportCommand(projectId, developerId, request.StartedAt, request.EndedAt));

            if (response.IsSuccess)
                return Ok();

            return BadRequest(response.Errors);
        }

        /// <summary>
        /// Get developer time reports. //APENAS TESTE
        /// </summary>
        /// <param name="developerId">Developer ID</param>
        [HttpGet("{developerId}/reports")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDeveloperTimeReports([FromRoute] Guid developerId)
        {
            var result = await _mediator.Send(new GetTimeReportsQuery(developerId));

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        /// <summary>
        /// Get top 5 developers with more average worked hours this week.
        /// </summary>
        [HttpGet("ranking")]
        [ProducesResponseType(typeof(IEnumerable<RankingViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetWeekRanking()
        {
            var result = await _mediator.Send(new GetWeekRankingQuery());

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Errors);
        }
    }
}
