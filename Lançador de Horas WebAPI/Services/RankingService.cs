using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Services
{
    public class RankingService
    {
        private readonly LancadorContext _context;

        public RankingService(LancadorContext context)
        {
            _context = context;
        }

        public async Task<List<Ranking>> GetRanking()
        {
            var registros = _context.RegistrosDeHoras.Where(x => DateTime.Now >= x.DataInicio.AddDays(-7))
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
                    Nome = (await _context.Desenvolvedores.Where(dv => dv.Id == reg.Key).FirstOrDefaultAsync()).Nome.ToUpper(),
                    MediaHoras = total / 7
                });
            }

            return ranking;
        }
    }
}