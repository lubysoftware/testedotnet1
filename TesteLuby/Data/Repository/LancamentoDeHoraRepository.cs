using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Business.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class LancamentoDeHoraRepository : Repository<LancamentoDeHora>, ILancamentoDeHoraRepository
    {
        public LancamentoDeHoraRepository(ApiDbContext db) : base(db)
        {
        }

        public override async Task<LancamentoDeHora> ObterPorId(Guid id)
        {
            return await Db.Lancamentos
                .AsNoTracking()
                .Where(l => l.Id == id)
                .Include(l => l.Desenvolvedor)
                .Include(l => l.Projeto)
                .FirstOrDefaultAsync();
        }
        
        public async Task<IEnumerable<LancamentoDeHora>> ObterLancamentoPorDesenvolvedor(Guid desenvolvedorId)
        {
            return await Db.Lancamentos.AsNoTracking()
                .Where(l => l.Desenvolvedor.Id == desenvolvedorId)
                .ToListAsync();
        }
        
        public async Task<List<Ranking>> ObterRank()
        {
            var diaAtual = DateTime.Now.DayOfWeek;
            var diasRestantesParaHoje = diaAtual - DayOfWeek.Monday;
            var dataParaComecoDaSemana = DateTime.Now.AddDays(-diasRestantesParaHoje);
            var lancamentos = await Db.Lancamentos
                .AsNoTracking()
                .Include(l => l.Desenvolvedor)
                .Include(l => l.Projeto)
                .Where(l => l.DataCadastro <= dataParaComecoDaSemana)
                .ToListAsync();
            
            var rankings = new List<Ranking>();
            foreach (var l in lancamentos)
            {
                if (rankings.Any(it => it.DesenvolvedorId == l.Desenvolvedor.Id))
                {
                    var rankAtualizado = rankings.First(it => it.DesenvolvedorId == l.Desenvolvedor.Id);
                    rankAtualizado.HorasTrabalhadas = l.HoraInicio.Hour - l.HoraFim.Hour;
                }
                else
                {
                    var rank = new Ranking
                    {
                        DesenvolvedorId = l.Desenvolvedor.Id,
                        HorasTrabalhadas = l.HoraInicio.Hour - l.HoraFim.Hour
                    };
                    rankings.Add(rank);   
                }
            }
            return rankings.OrderByDescending(it => it.HorasTrabalhadas).ToList();
        }
    }
}