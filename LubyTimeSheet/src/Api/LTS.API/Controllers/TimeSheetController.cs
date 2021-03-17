using LTS.Domain.Base;
using LTS.Domain.Commands;
using LTS.Domain.Commands.TimeSheet;
using LTS.Domain.Handlers;
using LTS.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LTS.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/timesheet")]
    public class TimeSheetController : ControllerBase
    {
        private readonly ITimeSheetService _timeSheetService;

        public TimeSheetController(ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
        }

        [HttpGet]
        [Route("projectId:guid")]
        public async Task<GenericCommandResult> GetById(Guid timeSheetId)
        {
            return await _timeSheetService.GetById(timeSheetId);
        }

        [HttpGet]
        public async Task<GenericCommandResult> GetAllPaginated([FromQuery] PaginationParameters paginationParameters)
        {
            return await _timeSheetService.GetAllPaginated(paginationParameters);
        }
        [HttpPut]
        public async Task<GenericCommandResult> Update([FromBody] UpdateTimeSheetCommand command, [FromServices] TimeSheetHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateTimeSheetCommand command, [FromServices] TimeSheetHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpDelete]

        public async Task<GenericCommandResult> Delete([FromBody] DeleteTimeSheetCommand command, [FromServices] TimeSheetHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}
