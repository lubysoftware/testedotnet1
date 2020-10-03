using TesteLuby.MainStartUp.Utilities;
using TesteLuby.Domain.Commands;
using TesteLuby.Domain.Contracts;
using TesteLuby.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteLuby.Domain.CommandsParameters;

namespace TesteLuby.MainStartUp.Controllers
{
    /// <summary>
    /// Controller desenvolvedor
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
 
    public class DeveloperController : ControllerBase
    {
        private readonly DeveloperHandler _handler;
        private readonly IAppSettings _settings;

        /// <summary>
        /// Construtor controller desenvolvedor
        /// </summary>
        /// <param name="handler">Servico de acesso aos Dados</param>
        /// <param name="settings">Configurações Gerais do sistema</param>
        public DeveloperController(DeveloperHandler handler, IAppSettings settings)
        {
            _handler = handler ?? throw new ArgumentNullException(nameof(handler));
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        /// <summary>
        /// Busca desenvolvedor pelo e-mail
        /// </summary>
        /// <returns>Lista desenvolvedor pelo e-mail (JSON)</returns>
        [HttpGet("email")]
        public async Task<IActionResult> GetUserByEmail([FromBody]GetDeveloperByEmailCommand user)
        {
            var users = await _handler.GetByEmail(user);
            if (users.Success)
            {
                return Ok(users);
            }
            else
            {
                return StatusCode(500, users);
            }
        }

        /// <summary>
        /// Lançamento de hora
        /// </summary>
        [HttpPost("businessHour")]
        [AllowAnonymous]
        public async Task<IActionResult> PostBusinessHour(CreateBusinessHourCommand command)
        {
            var users= await _handler.CreateBusinessHourDeveloper(command);
            if (users.Success)
            {
                return Ok(users);
            }
            else
            {
                switch (users.Status)
                {
                    case 400:
                        return BadRequest(users);
                    case 406:
                        return BadRequest(users);
                    case 500:
                        return StatusCode(500, users);
                    default:
                        return BadRequest(users);
                }
            }
        }

        /// <summary>
        /// Adiciona um novo desenvolvedor
        /// </summary>
        [HttpPost("add")]
        [AllowAnonymous]
        public async Task<IActionResult> PostUser(CreateDeveloperCommand user)
        {
            user.Password = user.Password.Criptografa();
            var users = await _handler.CreateDeveloper(user);
            if (users.Success)
            {
                return Ok(users);
            }
            else
            {
                switch (users.Status)
                {
                    case 400:
                        return BadRequest(users);
                    case 406:
                        return BadRequest(users);
                    case 500:
                        return StatusCode(500, users);
                    default:
                        return BadRequest(users);
                }
            }
        }

        /// <summary>
        /// Altera informações do desenvolvedor
        /// </summary>
        /// <param name="update"></param>
        /// <returns>Altera informações do usuário</returns>
        [HttpPut("update")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser(UpdateDeveloperCommand update)
        {
            var users = await _handler.UpdateDeveloper(update);
            if (users.Success)
            {
                return Ok(users);
            }
            else
            {
                switch (users.Status)
                {
                    case 400:
                        return BadRequest(users);
                    case 406:
                        return BadRequest(users);
                    case 500:
                        return StatusCode(500, users);
                    default:
                        return BadRequest(users);
                }
            }
        }

        /// <summary>
        /// Remove um developer
        /// </summary>
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteDeveloperCommand developer)
        {
            var delete = await _handler.DeleteDeveloper(developer);
            if (delete.Success)
            {
                return Ok(delete);
            }
            else
            {
                switch (delete.Status)
                {
                    case 400:
                        return BadRequest(delete);
                    case 404:
                        return NotFound(delete);
                    case 500:
                        return StatusCode(500, delete);
                    default:
                        return BadRequest(delete);
                }
            }
        }
    }
}
