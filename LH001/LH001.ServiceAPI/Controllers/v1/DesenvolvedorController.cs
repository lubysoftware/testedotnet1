using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH001.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LH001.ServiceAPI.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    //[Route("Desenvolvedor")]
    public class DesenvolvedorController : ControllerBase
    {
        private readonly BdContext _context;
        private readonly ILogger<DesenvolvedorController> _logger;

        public DesenvolvedorController(ILogger<DesenvolvedorController> logger, BdContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get todos os Desenvolvedores, sem nenhum parametro. Versão atual 1.0
        /// </summary>
        /// <returns>Retorna uma lista do tipo desenvolvedor</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/Desenvolvedor/Listar")]
        public async Task<IActionResult> ListarDesenvolvedores()
        {
            try
            {
                var l =  await _context.Tb_Desenvolvedores.ToListAsync();
                return StatusCode(200, l);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                _logger.LogError(ex, "ErrorId: {0}", errorId.ToString());
                return StatusCode(500, new { ErrorId = errorId.ToString(), Mensagem = ex.Message });
            }
        }

    }
}
