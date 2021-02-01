using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH001.Contexto;
using LH001.Domain.Entidades;
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


        /// <summary>
        /// Get os Desenvolvedores por nome ou Id. Versão atual 1.0
        /// </summary>
        /// <param name="Id">Numero do Id para pesquisa. Deve ser = 0 se não for buscar por ele</param>
        /// <param name="Nome">Nome do desenvolvedor, Parte ou inteiro</param>
        /// <returns>Retorna uma lista do tipo desenvolvedor</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/Desenvolvedor/Buscar")]
        public async Task<IActionResult> BuscarDesenvolvedores(string Id, string Nome)
        {
            try
            {
                var l = await _context.Tb_Desenvolvedores.Where(x=> !String.IsNullOrEmpty(Nome) ? x.Nome.ToLower().Contains(Nome.ToLower()) : true
                                                                && Id != "0" ? x.Id == int.Parse(Id) : true).ToListAsync();
                return StatusCode(200, l);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                _logger.LogError(ex, "ErrorId: {0}", errorId.ToString());
                return StatusCode(500, new { ErrorId = errorId.ToString(), Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Adiciona o um novo Desenvolvedor. Versão atual 1.0
        /// </summary>
        /// <param name="Nome">Nome do desenvolvedor, não deve ser um já cadastrado.</param>
        [HttpPost]
        [Route("Api/v{version:apiVersion}/Desenvolvedor/Incluir")]
        public async Task<IActionResult> Incluir(string Nome)
        {
            try
            {
                var D = new Tb_Desenvolvedor();
                D.Nome = Nome;
                await _context.Tb_Desenvolvedores.AddAsync(D);
                await _context.SaveChangesAsync();
                return StatusCode(200);
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
