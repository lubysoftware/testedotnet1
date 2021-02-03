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
    public class LancamentoHoraController : ControllerBase
    {
        private readonly BdContext _context;
        private readonly ILogger<LancamentoHoraController> _logger;

        public LancamentoHoraController(ILogger<LancamentoHoraController> logger, BdContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Get todos os lançamentos de horario, sem nenhum parametro. Versão atual 1.0
        /// </summary>
        /// <returns>Retorna uma lista do tipo LancamentoHora</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/LancamentoHora/Listar")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var l = await _context.Tb_LancamentosHoras
                    .Include(x => x.Tb_Desenvolvedor_Projeto)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Projeto)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Desenvolvedor).ToListAsync();
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
        /// Get os lançamentos de horario por nome do Desenvolvedor ou Id do projeto. Versão atual 1.0
        /// </summary>
        /// <param name="NomeDesenv">Nome do desenvolvedor, Parte ou inteiro</param>
        /// <param name="IdProj">Id do Projeto. Deve ser = 0 se não for buscar por ele</param>
        /// <returns>Retorna uma lista do tipo LancamentoHora</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/LancamentoHora/Buscar")]
        public async Task<IActionResult> Buscar(string NomeDesenv, string IdProj)
        {
            try
            {
                var l = await _context.Tb_LancamentosHoras
                    .Include(x => x.Tb_Desenvolvedor_Projeto)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Desenvolvedor)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Projeto)
                    .Where(x => (!String.IsNullOrEmpty(NomeDesenv) ? x.Tb_Desenvolvedor_Projeto.Tb_Desenvolvedor.Nome.ToLower().Contains(NomeDesenv.ToLower()) : true)
                           && (IdProj != "0" ? x.Tb_Desenvolvedor_Projeto.Tb_ProjetoId == int.Parse(IdProj) : true)).ToListAsync();
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
        /// Get os desenvolvedores com as horas de trabalho, dias trabalhados e sua media de desenpenho, de acordo com a semana atual. Versão atual 1.0
        /// </summary>
        /// <returns>Retorna uma lista do tipo Desenvolvedor_Projeto</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/LancamentoHora/EstatisticaPorDesenvolvedor")]
        public async Task<IActionResult> EstatisticaPorDesenvolvedor()
        {
            try
            {
                var l = await _context.Tb_LancamentosHoras
                    .Include(x => x.Tb_Desenvolvedor_Projeto)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Desenvolvedor)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Projeto)
                    .ToListAsync();

                var listaLH = new List<Tb_LancamentoHoras>();
                var listaD = new List<Tb_Desenvolvedor_Projeto>();
                DateTime DiaAtual = DateTime.Now.Date;
                bool FimLancamentos = false;
                while (listaD.Count() <= 5 && FimLancamentos == false)
                {
                    for (var item = 0; item < (int)DiaAtual.DayOfWeek; item++)
                    {
                        var dataAComparar = DiaAtual.AddDays(-(item + 1));
                        var lh = l.Where(x => x.DataInicio <= dataAComparar && dataAComparar <= x.DataFim).ToList();
                        foreach (var item_lancamentoH in lh)
                        {
                            if (!listaLH.Any(x => x.Id == item_lancamentoH.Id))
                            {
                                listaLH.Add(item_lancamentoH);
                            }
                        }
                    }
                    foreach (var item in listaLH)
                    {
                        if (!listaD.Any(x => x.Tb_DesenvolvedorId == item.Tb_Desenvolvedor_Projeto.Tb_DesenvolvedorId))
                        {
                            item.Tb_Desenvolvedor_Projeto.ProjetosEstatisticas = "";
                            listaD.Add(item.Tb_Desenvolvedor_Projeto);
                        }
                        var D = listaD.FirstOrDefault(x => x.Tb_DesenvolvedorId == item.Tb_Desenvolvedor_Projeto.Tb_DesenvolvedorId);

                        var dataMaxInicio = DiaAtual.AddDays(-((int)DiaAtual.DayOfWeek + 1));
                        var dataInicio = item.DataInicio >= dataMaxInicio ? item.DataInicio : dataMaxInicio;
                        item.DataFim = item.DataFim.AddDays(1); // contar o proprio dia ex: inicio dia 30 termino 31 com isso vai contar 2 dias
                        TimeSpan timeTotais;
                        var HorasSplit = D.HorasTotais.ToString().Split(",");
                        if(D.HorasTotais == 0)
                            timeTotais = new TimeSpan(00,00, 0);
                        else
                            timeTotais = new TimeSpan(int.Parse(HorasSplit[0]), HorasSplit.Count() == 1 ? 00 : int.Parse(HorasSplit[1]), 0);

                        TimeSpan HorasTotais;

                        var DiasNaSemana = (DiaAtual - dataMaxInicio).Days;

                        if (item.DataInicio >= dataMaxInicio)
                        {
                            var HorasItemSplit = item.Horas.Split(":");
                            var timeItem = new TimeSpan(int.Parse(HorasItemSplit[0]), int.Parse(HorasItemSplit[1]), 0);

                            HorasTotais = timeTotais.Add(timeItem);
                        }
                        else
                        {
                            
                            var HorasCadastrados = double.Parse(item.Horas.Replace(":", ","));

                            var DiasCadastrados = (item.DataFim - item.DataInicio).Days;


                            var HorasCorrigido = Math.Round((HorasCadastrados / DiasCadastrados) * DiasNaSemana, 2);

                            var HorasItemSplit = HorasCorrigido.ToString().Split(",");
                            var timeItem = new TimeSpan(int.Parse(HorasItemSplit[0]), HorasSplit.Count() == 1 ? 00 : int.Parse(HorasItemSplit[1]), 0);

                            HorasTotais = timeTotais.Add(timeItem);

                        }
                        D.HorasTotais = Math.Round(HorasTotais.TotalHours, 2);
                        if (!D.ProjetosEstatisticas.Contains(item.Tb_Desenvolvedor_Projeto.Tb_Projeto.Nome))
                            D.ProjetosEstatisticas = D.ProjetosEstatisticas + item.Tb_Desenvolvedor_Projeto.Tb_Projeto.Nome + " / ";
                        D.NumeroDiasTrabalhados = D.NumeroDiasTrabalhados + (item.DataFim - dataInicio).Days;

                        if (D.NumeroDiasTrabalhados > DiasNaSemana)
                            D.NumeroDiasTrabalhados = DiasNaSemana;


                    }
                    foreach (var item in listaD)
                    {
                        item.Media = (int)((item.HorasTotais / (item.NumeroDiasTrabalhados * 12)) * 100);
                    }
                    FimLancamentos = true;
                }

                return StatusCode(200, listaD.OrderByDescending(x=>x.Media).ToList());
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                _logger.LogError(ex, "ErrorId: {0}", errorId.ToString());
                return StatusCode(500, new { ErrorId = errorId.ToString(), Mensagem = ex.Message });
            }
        }


        /// <summary>
        /// Get os projetos com as horas de trabalho, dias trabalhados e sua media de desenpenho, de acordo com a semana atual. Versão atual 1.0
        /// </summary>
        /// <returns>Retorna uma lista do tipo Desenvolvedor_Projeto</returns>
        [HttpGet]
        [Route("Api/v{version:apiVersion}/LancamentoHora/EstatisticaPorProjeto")]
        public async Task<IActionResult> EstatisticaPorProjeto()
        {
            try
            {
                var l = await _context.Tb_LancamentosHoras
                    .Include(x => x.Tb_Desenvolvedor_Projeto)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Desenvolvedor)
                    .Include(x => x.Tb_Desenvolvedor_Projeto.Tb_Projeto)
                    .ToListAsync();

                var listaLH = new List<Tb_LancamentoHoras>();
                var listaD = new List<Tb_Desenvolvedor_Projeto>();
                DateTime DiaAtual = DateTime.Now.Date;
                bool FimLancamentos = false;
                while (listaD.Count() <= 5 && FimLancamentos == false)
                {
                    for (var item = 0; item < (int)DiaAtual.DayOfWeek; item++)
                    {
                        var dataAComparar = DiaAtual.AddDays(-(item + 1));
                        var lh = l.Where(x => x.DataInicio <= dataAComparar && dataAComparar <= x.DataFim).ToList();
                        foreach (var item_lancamentoH in lh)
                        {
                            if (!listaLH.Any(x => x.Id == item_lancamentoH.Id))
                            {
                                listaLH.Add(item_lancamentoH);
                            }
                        }
                    }
                    foreach (var item in listaLH)
                    {
                        if (!listaD.Any(x => x.Tb_ProjetoId == item.Tb_Desenvolvedor_Projeto.Tb_ProjetoId))
                        {
                            item.Tb_Desenvolvedor_Projeto.ProjetosEstatisticas = "";
                            listaD.Add(item.Tb_Desenvolvedor_Projeto);
                        }
                        var D = listaD.FirstOrDefault(x => x.Tb_ProjetoId == item.Tb_Desenvolvedor_Projeto.Tb_ProjetoId);

                        var dataMaxInicio = DiaAtual.AddDays(-((int)DiaAtual.DayOfWeek + 1));
                        var dataInicio = item.DataInicio >= dataMaxInicio ? item.DataInicio : dataMaxInicio;
                        item.DataFim = item.DataFim.AddDays(1); // contar o proprio dia ex: inicio dia 30 termino 31 com isso vai contar 2 dias
                        TimeSpan timeTotais;
                        var HorasSplit = D.HorasTotais.ToString().Split(",");
                        if (D.HorasTotais == 0)
                            timeTotais = new TimeSpan(00, 00, 0);
                        else
                            timeTotais = new TimeSpan(int.Parse(HorasSplit[0]), HorasSplit.Count() == 1 ? 00 : int.Parse(HorasSplit[1]), 0);

                        TimeSpan HorasTotais;
                        var DiasNaSemana = (DiaAtual - dataMaxInicio).Days;
                        if (item.DataInicio >= dataMaxInicio)
                        {
                            var HorasItemSplit = item.Horas.Split(":");
                            var timeItem = new TimeSpan(int.Parse(HorasItemSplit[0]), int.Parse(HorasItemSplit[1]), 0);

                            HorasTotais = timeTotais.Add(timeItem);
                        }
                        else
                        {
                            var HorasCadastrados = double.Parse(item.Horas.Replace(":", ","));

                            var DiasCadastrados = (item.DataFim - item.DataInicio).Days;
                            

                            var HorasCorrigido = Math.Round((HorasCadastrados / DiasCadastrados) * DiasNaSemana, 2);

                            var HorasItemSplit = HorasCorrigido.ToString().Split(",");
                            var timeItem = new TimeSpan(int.Parse(HorasItemSplit[0]), HorasSplit.Count() == 1 ? 00 : int.Parse(HorasItemSplit[1]), 0);

                            HorasTotais = timeTotais.Add(timeItem);
                        }
                        if (!D.ProjetosEstatisticas.Contains(item.Tb_Desenvolvedor_Projeto.Tb_Desenvolvedor.Nome))
                            D.ProjetosEstatisticas = D.ProjetosEstatisticas + item.Tb_Desenvolvedor_Projeto.Tb_Desenvolvedor.Nome + " / ";
                        D.HorasTotais = Math.Round(HorasTotais.TotalHours, 2);
                        D.NumeroDiasTrabalhados = D.NumeroDiasTrabalhados + (item.DataFim - dataInicio).Days;

                        if (D.NumeroDiasTrabalhados > DiasNaSemana)
                            D.NumeroDiasTrabalhados = DiasNaSemana;
                    }
                    foreach (var item in listaD)
                    {
                        var DevsPorProj = item.ProjetosEstatisticas.Split("/").Count() - 1;
                        item.Media = (int)((item.HorasTotais / (item.NumeroDiasTrabalhados * (12* DevsPorProj))) * 100);
                    }
                    FimLancamentos = true;
                }

                return StatusCode(200, listaD.OrderByDescending(x => x.Media).ToList());
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();
                _logger.LogError(ex, "ErrorId: {0}", errorId.ToString());
                return StatusCode(500, new { ErrorId = errorId.ToString(), Mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Adiciona o um novo LancamentoHora. Versão atual 1.0
        /// </summary>
        /// <param name="Desenv_Proj_Id">Id correspondente a tabela Desenvolvedor_Projeto</param>
        /// <param name="DataInicio">Data de inicio do lançamento</param>
        /// <param name="DataFim">Data do fim do lançamento</param>
        /// <param name="Hora">Horas trabalhadas durante o periodo, deve ser digitado como esse exemplo: "00:00"</param>
        [HttpPost]
        [Route("Api/v{version:apiVersion}/LancamentoHora/Incluir")]
        public async Task<IActionResult> Incluir(string Desenv_Proj_Id, string DataInicio, string DataFim, string Hora)
        {
            try
            {
                var lh = new Tb_LancamentoHoras();
                lh.Tb_Desenvolvedor_ProjetoId = int.Parse(Desenv_Proj_Id);
                lh.DataInicio = DateTime.Parse(DataInicio);
                lh.DataFim = DateTime.Parse(DataFim);
                lh.Horas = Hora;

                await _context.Tb_LancamentosHoras.AddAsync(lh);
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
        /// Deleta um LancamentoHora. Versão atual 1.0
        /// </summary>
        /// <param name="Id">Id do LançamentoHora para ser deletado.</param>
        [HttpDelete]
        [Route("Api/v{version:apiVersion}/LancamentoHora/Excluir")]
        public async Task<IActionResult> Excluir(string Id)
        {
            try
            {
                var lh = await _context.Tb_LancamentosHoras.FirstOrDefaultAsync(x => x.Id == int.Parse(Id));
                _context.Tb_LancamentosHoras.RemoveRange(lh);
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
