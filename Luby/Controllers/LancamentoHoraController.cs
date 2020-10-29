using Luby.Models;
using Luby.Repositorios;
using Luby.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luby.Controllers
{
    [Produces("application/json")]
    [Route("api/lancamentohora")]
    public class LancamentoHoraController : BaseController
    {
        private readonly Context _context;
        private IConfiguration _config;
        IHttpContextAccessor accessor;
        private readonly IHostingEnvironment environment;
        LancamentoHoraRepositorio _lancamentoHoraRepositorio;
        ProjetoRepositorio _projetoRepositorio;
        DesenvolvedorRepositorio _desenvolvedorRepositorio;

        public LancamentoHoraController(IConfiguration config, Context context, IHttpContextAccessor accessor, IHostingEnvironment environment) : base(config, context, accessor)
        {
            _config = config;
            _context = context;
            _lancamentoHoraRepositorio = new LancamentoHoraRepositorio(_context);
            _projetoRepositorio = new ProjetoRepositorio(_context);
            _desenvolvedorRepositorio = new DesenvolvedorRepositorio(_context);
            this.accessor = accessor;
            this.environment = environment;
        }

        [Authorize, HttpPost]
        public async Task<IActionResult> Post([FromBody] LancamentoHoraViewModel model)
        {
            try
            {
                LancamentoHora obj = new LancamentoHora();

                obj.DataInicio = model.DataInicio;
                obj.DataFim = model.DataFim;

                obj.Projeto = _projetoRepositorio.FindBy(p => p.Id == model.IdProjeto).FirstOrDefault();

                if (obj.Projeto == null)
                {
                    return BadRequest("Projeto invalido.");
                }

                obj.Desenvolvedor = _desenvolvedorRepositorio.FindBy(p => p.Id == user.Id).FirstOrDefault();


                await _lancamentoHoraRepositorio.AddAndSaveAsync(obj);


                return Ok(obj);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [Authorize, HttpGet("ranking")]
        public async Task<IActionResult> getRaking()
        {
            try
            {
                List<LancamentoHora> list = _lancamentoHoraRepositorio.GetAll().Include("Desenvolvedor").ToList();
                List<RankingViewModel> rankings = new List<RankingViewModel>();

                list = getSemana(list);

                foreach(LancamentoHora lancamento in list)
                {
                    RankingViewModel rank = rankings.Where(p => p.Desenvolvedor.Id == lancamento.Desenvolvedor.Id).FirstOrDefault();
                    if(rank == null)
                    {
                        rank = new RankingViewModel();
                        rank.Desenvolvedor = lancamento.Desenvolvedor;
                        rank.Horas = lancamento.DataFim.Hour - lancamento.DataInicio.Hour;
                        rankings.Add(rank);
                    }
                    else
                    {
                        rank.Horas += lancamento.DataFim.Hour - lancamento.DataInicio.Hour;
                        rankings.Where(p => p.Desenvolvedor.Id == lancamento.Desenvolvedor.Id).Select(p => p.Horas = rank.Horas);
                    }
                }

                rankings = rankings.OrderByDescending(p => p.Horas).Take(5).ToList();
                rankings = limpaSenha(rankings);

                return Ok(rankings);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        public List<LancamentoHora> getSemana(List<LancamentoHora> lista)
        {
            List<LancamentoHora> retorno = new List<LancamentoHora>();


            foreach (LancamentoHora hora in lista)
            {
                var cal = System.Globalization.DateTimeFormatInfo.CurrentInfo.Calendar;
                var d1 = hora.DataFim.Date.AddDays(-1 * (int)cal.GetDayOfWeek(hora.DataFim.Date));
                var d2 = DateTime.Now.Date.AddDays(-1 * (int)cal.GetDayOfWeek(DateTime.Now.Date));

                if (d1 == d2)
                {
                    retorno.Add(hora);
                }

            }

            return retorno;

        }

        public List<RankingViewModel> limpaSenha(List<RankingViewModel> lista)
        {
            foreach (RankingViewModel rank in lista)
            {
                rank.Desenvolvedor.Senha = "";
            }

            return lista;

        }
    }
}
