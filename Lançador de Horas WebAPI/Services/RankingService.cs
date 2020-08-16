using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Services
{
    /// <summary>
    /// Serviço de cálculo de média de horas dos desenvolvedores
    /// </summary>
    public class RankingService
    {
        private readonly LancadorContext _context;

        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="context">Contexto de dados</param>
        public RankingService(LancadorContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém o ranking
        /// </summary>
        /// <returns>Lista dos 5 desenvolvedores com maior média de horas trabalhadas durante a semana</returns>
        public async Task<List<Ranking>> GetRanking()
        {
            var registros = _context.RegistrosDeHoras.Where(x => x.DataInicio >= ObterInicioSemana() && x.DataFim <= ObterInicioSemana().AddDays(6))
                 .AsEnumerable()
                 .GroupBy(x => x.DesenvolvedorId, x => x.TotalHoras);

            List<Ranking> ranking = new List<Ranking>();

            foreach (IGrouping<int, TimeSpan> reg in registros)
            {
                TimeSpan total = new TimeSpan();

                foreach (TimeSpan horas in reg)
                {
                    total += horas;
                }

                ranking.Add(new Ranking()
                {
                    Desenvolvedor = await _context.Desenvolvedores.Where(dv => dv.Id == reg.Key).FirstOrDefaultAsync(),
                    MediaHoras = total / 7
                });
            }

            return ranking;
        }

        /// <summary>
        /// Obtém o último domingo
        /// </summary>
        /// <returns>A data referente ao último domingo</returns>
        private DateTime ObterInicioSemana()
        {
            DateTime Now = DateTime.Now;

            return Now.DayOfWeek switch
            {
                DayOfWeek.Sunday => Now,
                DayOfWeek.Monday => Now.AddDays(-1),
                DayOfWeek.Tuesday => Now.AddDays(-2),
                DayOfWeek.Wednesday => Now.AddDays(-3),
                DayOfWeek.Thursday => Now.AddDays(-4),
                DayOfWeek.Friday => Now.AddDays(-5),
                DayOfWeek.Saturday => Now.AddDays(-6),
                _ => Now,
            };
        }
    }
}