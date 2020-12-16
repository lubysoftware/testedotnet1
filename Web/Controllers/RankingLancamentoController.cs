using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Web.Model;

namespace Web.Controllers
{
    public class RankingLancamentoController : Controller
    {
        LancamentoServices lancamentoServices = new LancamentoServices();
        DesenvolvedorServices desenvolvedorServices = new DesenvolvedorServices();

        // GET: RankingLancamentoController
        public ActionResult Index()
        {
            //Busca semana atual
            DateTime diaInicialSemana = DateTime.Today.AddDays((int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)DateTime.Today.DayOfWeek);

            //Busca todos os dias da semana
            var diasDaSemana = Enumerable.Range(0, 7).Select(i => diaInicialSemana.AddDays(i)).ToList();

            //Busca todos os lancamentos entre o intervalo de inicio e fim da semana
            lancamentoServices.SetEndpoint("Lancamento");
            var lancamentosGet = lancamentoServices.Get().Result;
            var lancamentos = lancamentosGet.Where(x => x.DataInicio >= diasDaSemana.First() && x.DataFim <= diasDaSemana.Last()).ToList();

            var lsDevs = lancamentos.Select(x => x.IdDesenvolvedor).Distinct().ToList();

            var lsRanking = new List<RankingLancamentoModel>();

            foreach (var d in lsDevs)
            {
                //utilizar outro parametro para buscar o exato dev
                var horasDev = lancamentos.Where(x => x.IdDesenvolvedor == d).ToList();
                var rankingHoras = new RankingLancamentoModel();
                var totalMediaHoras = 0;
                var totalDias = 0;

                foreach (var item in horasDev)
                {
                    desenvolvedorServices.SetEndpoint("Desenvolvedor");

                    rankingHoras.IdDesenvolvedor = item.IdDesenvolvedor;
                    rankingHoras.NomeDesenvolvedor = desenvolvedorServices.Get().Result.Where(x => x.Id == item.IdDesenvolvedor).FirstOrDefault().Nome;

                    var horaInicio = item.DataInicio.TimeOfDay;
                    var horaFim = item.DataFim.TimeOfDay;

                    var totalHoras = horaFim - horaInicio;
                    totalMediaHoras += totalHoras.Hours;
                    totalDias++;
                }

                rankingHoras.MediaHoras = ((double)totalMediaHoras / (double)totalDias);

                lsRanking.Add(rankingHoras);
            }

            var model = lsRanking.OrderByDescending(x => x.MediaHoras).Take(5).ToList();

            return View(model);
        }

    }
}
