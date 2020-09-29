using LTS.Domain.Base;
using LTS.Domain.Commands;
using LTS.Domain.Commands.Developer;
using LTS.Domain.Handlers;
using LTS.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LTS.API.Controllers
{
    [ApiController]
    [Route("api/developer")]
    [Authorize]
    public class DeveloperController : ControllerBase
    {
        private readonly IDeveloperService _developerService;
        public DeveloperController(IDeveloperService developerService)
        {
            _developerService = developerService;
        }

        [HttpGet]
        [Route("developerId:guid")]
        public async Task<GenericCommandResult> GetById(Guid developerId)
        {
            return await _developerService.GetById(developerId);
        }

        [HttpGet]
        [Route("topfive")]
        public async Task<GenericCommandResult> GetHoursWorked()
        {
            return await _developerService.GetDeveloperWithHours();
        }

        [HttpGet]
        public async Task<GenericCommandResult> GetAllPaginated([FromQuery] PaginationParameters paginationParameters)
        {
            return await _developerService.GetAllPaginated(paginationParameters);
        }

        [HttpPut]
        public async Task<GenericCommandResult> Update([FromBody] UpdateDeveloperCommand command, [FromServices] DeveloperHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateDeveloperCommand command, [FromServices] DeveloperHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [HttpDelete]

        public async Task<GenericCommandResult> Delete([FromBody] DeleteDeveloperCommand command, [FromServices] DeveloperHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}
