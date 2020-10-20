using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeSheetManager.App.Handlers.TimeSheetNS;
using TimeSheetManager.App.Commands;
using TimeSheetManager.App.Commands.TimeSheet;
using TimeSheetManager.Domain.Entities.TimeSheetNS;
using TimeSheetManager.Domain.Repositories;
using TimeSheetManager.Domain.Entities.DeveloperNS;

namespace TimeSheetManager.Api.Controllers {
    [ApiController]
    [Route("v1/timesheet")]
    public class TimeSheetController : ControllerBase {
        [HttpPost("{devId}")]
        public async Task<GenericCommandResult> Create(Guid devId, [FromBody] WorkedTime workedtime, [FromServices] CreateTimeSheetHandler handler) {
            var timesheet = new CreateTimeSheetCommand(devId, workedtime.Entry, workedtime.Exit);
            return (GenericCommandResult)await handler.Handle(timesheet);
        }
        [HttpGet]
        public async Task<GenericCommandResult> GetWeekRanking([FromServices] GetWeekRankingHandler handler) {
            return (GenericCommandResult)await handler.Handle();
        }
    }
}