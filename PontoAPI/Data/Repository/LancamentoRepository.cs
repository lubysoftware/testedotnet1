using System;
using PontoAPI.Domain.Interfaces;
using PontoAPI.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PontoAPI.Data.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly PontoContext dbContext;

        public LancamentoRepository(PontoContext context)
        {
            dbContext = context;
        }

        public bool Create(Lancamento lancamento)
        {
            try
            {
                lancamento.HoraInicio = DateTime.Now;

                dbContext.LancamentoSet.Add(lancamento);
                dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetLancamentos()
        {
            try
            {
                var lancamentos = dbContext.LancamentoSet.Select(t => t).ToList();
                return JsonConvert.SerializeObject(lancamentos);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public string RankingSemanal()
        {
            try
            {
                var ranking = dbContext.LancamentoSet
                .Join(dbContext.DesenvolvedorSet,
                lanc => lanc.Desenvolvedor.DesenvolvedorID,
                dev => dev.DesenvolvedorID,
                (lanc, dev) => new { Lanc = lanc.HoraFim.Value.Subtract(lanc.HoraInicio), Dev = dev.Nome });

                return JsonConvert.SerializeObject(ranking.Take(5));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}