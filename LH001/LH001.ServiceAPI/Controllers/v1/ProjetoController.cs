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
    public class ProjetoController : ControllerBase
    {
        private readonly BdContext _context;
        private readonly ILogger<ProjetoController> _logger;

        public ProjetoController(ILogger<ProjetoController> logger, BdContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get todos os Projetos, sem nenhum parametro. Versão atual 1.0
        /// </summary>
        /// <returns>Retorna uma lista do tipo projeto</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/Projeto/Listar")]
        public async Task<IActionResult> ListarProjetos()
        {
            try
            {
                var l = await _context.Tb_Projetos.ToListAsync();
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
        /// Get os Projetos por nome ou Id. Versão atual 1.0
        /// </summary>
        /// <param name="Id">Numero do Id para pesquisa. Deve ser = 0 se não for buscar por ele</param>
        /// <param name="Nome">Nome do projeto, Parte ou inteiro</param>
        /// <returns>Retorna uma lista do tipo projeto</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/Projeto/Buscar")]
        public async Task<IActionResult> Buscar(string Id, string Nome)
        {
            try
            {
                var l = await _context.Tb_Projetos.Where(x => (!String.IsNullOrEmpty(Nome) ? x.Nome.ToLower().Contains(Nome.ToLower()) : true)
                                                                && (Id != "0" ? x.Id == int.Parse(Id) : true) 
                                                                && (x.InAtivo == true)).ToListAsync();
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
        /// Get os desenvolvedores por id do projeto. Versão atual 1.0
        /// </summary>
        /// <param name="Id">Id do projeto para pesquisa. Nesse caso não pode ser nulo</param>
        /// <returns>Retorna uma lista do tipo projeto</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/Projeto/DesenvolvedoresPorProjetoId")]
        public async Task<IActionResult> DesenvolvedoresPorProjetoId(string Id)
        {
            try
            {
                var l = await _context.Tb_Desenvolvedores_Projetos.Include(x=>x.Tb_Desenvolvedor).Where(x => x.Tb_ProjetoId == int.Parse(Id) && x.InAtivo == true).ToListAsync();
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
        /// Adiciona o um novo Projeto. Versão atual 1.0
        /// </summary>
        /// <param name="Nome">Nome do desenvolvedor, não deve ser um já cadastrado.</param>
        /// <param name="Desenvolvedores">Nomes dos desenvolvedores, para ser cadastrado na tabela Tb_Desenvolvedor_Projeto, eles devem ser separados por "\" e devem existir no banco do Desenvolvedor.</param>
        [HttpPost]
        [Route("Api/v{version:apiVersion}/Projeto/Incluir")]
        public async Task<IActionResult> Incluir(string Nome, string Desenvolvedores)
        {
            try
            {
                var P = new Tb_Projeto();
                P.InAtivo = true;
                P.Nome = Nome;
                await _context.Tb_Projetos.AddAsync(P);
                await _context.SaveChangesAsync();

                int Proj_id = P.Id;
                if (Desenvolvedores != null)
                {
                    var DevsArray = Desenvolvedores.Split("/");
                    foreach (var item in DevsArray)
                    {
                        if (!String.IsNullOrEmpty(item))
                        {
                            var tbDev_proj = new Tb_Desenvolvedor_Projeto();
                            tbDev_proj.Tb_ProjetoId = Proj_id;
                            tbDev_proj.InAtivo = true;

                            tbDev_proj.Tb_Desenvolvedor = _context.Tb_Desenvolvedores.FirstOrDefault(x => x.Nome == item);
                            if (tbDev_proj.Tb_Desenvolvedor != null)
                            {
                                tbDev_proj.Tb_DesenvolvedorId = tbDev_proj.Tb_Desenvolvedor.Id;
                                await _context.Tb_Desenvolvedores_Projetos.AddAsync(tbDev_proj);
                            }
                        }
                    }
                }
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


        /// <summary>
        /// Altera o um Projeto. Versão atual 1.0
        /// </summary>
        /// <param name="Id">Id do desenvolvedor  que deve ser alterado.</param>
        /// <param name="Nome">Nome do desenvolvedor, não deve ser um já cadastrado.</param>
        /// /// <param name="Desenvolvedores">Nomes dos desenvolvedores, para ser cadastrado na tabela Tb_Desenvolvedor_Projeto, eles devem ser separados por "\" e devem existir no banco do Desenvolvedor.</param>
        [HttpPost]
        [Route("Api/v{version:apiVersion}/Projeto/Alterar")]
        public async Task<IActionResult> Alterar(string Id, string Nome, string Desenvolvedores)
        {
            try
            {
                var P = await _context.Tb_Projetos.FirstOrDefaultAsync(x => x.Id == int.Parse(Id));
                P.Nome = Nome;
                await _context.SaveChangesAsync();

                int Proj_id = P.Id;



                if (Desenvolvedores != null)
                {
                    var listaDesenvCadastrados = await _context.Tb_Desenvolvedores_Projetos.Include(x=>x.Tb_Desenvolvedor).Where(x => x.Tb_ProjetoId == Proj_id).ToListAsync();

                    var DevsArray = Desenvolvedores.Split("/");

                    //Adiciona os que novos
                    foreach (var item in DevsArray)
                    {
                        if (!String.IsNullOrEmpty(item))
                        {
                            if (!listaDesenvCadastrados.Any(x => x.Tb_Desenvolvedor.Nome == item))
                            {
                                var tbDev_proj = new Tb_Desenvolvedor_Projeto();
                                tbDev_proj.Tb_ProjetoId = Proj_id;
                                tbDev_proj.InAtivo = true;
                                tbDev_proj.Tb_Desenvolvedor = _context.Tb_Desenvolvedores.FirstOrDefault(x => x.Nome == item);
                                if (tbDev_proj.Tb_Desenvolvedor != null)
                                {
                                    tbDev_proj.Tb_DesenvolvedorId = tbDev_proj.Tb_Desenvolvedor.Id;
                                    await _context.Tb_Desenvolvedores_Projetos.AddAsync(tbDev_proj);
                                }
                            }
                            else
                            {
                                var DevNaoAtivo = listaDesenvCadastrados.FirstOrDefault(x => x.Tb_Desenvolvedor.Nome == item && x.InAtivo == false);
                                if (DevNaoAtivo != null)
                                    DevNaoAtivo.InAtivo = true;
                            }
                        }
                    }

                    //Coloca para InAtivo = false para os deletados
                    foreach (var item in listaDesenvCadastrados)
                    {
                        if (!DevsArray.Any(x => x == item.Tb_Desenvolvedor.Nome && item.InAtivo== true))
                        {
                            item.InAtivo = false;
                        }
                    }

                }



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


        /// <summary>
        /// Deleta um Projeto, quando apagado ele será retirado inativado, dessa forma os registros já cadastrados dos lancamentos de hora não serão perdidos. Versão atual 1.0
        /// </summary>
        /// <param name="Id">Id do desenvolvedor para ser deletado.</param>
        [HttpDelete]
        [Route("Api/v{version:apiVersion}/Projeto/Excluir")]
        public async Task<IActionResult> Excluir(string Id)
        {
            try
            {
                var dp = await _context.Tb_Desenvolvedores_Projetos.Where(x => x.Tb_ProjetoId == int.Parse(Id)).ToListAsync();

                foreach (var item in dp)
                {
                    item.InAtivo = false;
                }

                var d = await _context.Tb_Projetos.FirstOrDefaultAsync(x => x.Id == int.Parse(Id));
                d.InAtivo = false;

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
