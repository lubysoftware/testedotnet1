using LubyHour.Domain.Commands.Input.Management;
using LubyHour.Domain.Handlers;
using LubyHour.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LubyHour.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly ManagementHandler _handler;

        public ManagementController(ManagementHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Busca Todos os Lançamentos
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetAllManagement()
        {

            ICommandResult result = await _handler.GetAllManagement();
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        /// <summary>
        /// Busca o rank dos 5 Desenvolvedores que mais trabalharam
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet("rank")]
        public async Task<IActionResult> GetRank()
        {

            ICommandResult result = await _handler.GetRankDeveloper();
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        /// <summary>
        /// Busca um Lançamento pelo ID
        /// </summary>
        /// <param name="command">Dados da Categoria</param>
        /// <returns></returns>
        [HttpPost("id")]
        public async Task<IActionResult> GetManagementById([FromBody] GetManagementByIdCommand command)
        {
            ICommandResult result = await _handler.Handle(command);
            return result.Success ? Ok(result) : StatusCode(500, result);
        }


        /// <summary>
        /// Adiciona um novo Lançamento
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public async Task<IActionResult> PostManagement([FromBody] PostManagementCommand command)
        {
            ICommandResult result = await _handler.Handle(command);
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        /// <summary>
        /// Atualiza um Lançamento
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateManagement([FromBody] UpdateManagementCommand command)
        {
            ICommandResult result = await _handler.Handle(command);
            return result.Success ? Ok(result) : StatusCode(500, result);
        }

        /// <summary>
        /// Remove um Lançamento
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteManagement([FromBody] DeleteManagementCommand command)
        {
            ICommandResult result = await _handler.Handle(command);
            return result.Success ? Ok(result) : StatusCode(500, result);
        }
    }
}
