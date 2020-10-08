using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Services
{
    public class PontoService : ServiceBase<Ponto>, IPontoService
    {
        protected readonly IPontoRepository pontoRepository;
        public PontoService(IPontoRepository repo) : base(repo)
        {
            pontoRepository = repo;
        }

        public List<Pessoa> GetMediaPonto()
        {
            List<DateTime> dataSemana = GetDiasSemana();
            return pontoRepository.GetMediaPonto(dataSemana);
        }

        private List<DateTime> GetDiasSemana()
        {
            DateTime dataAtual = DateTime.Now;
                    
            while (dataAtual.DayOfWeek != DayOfWeek.Monday)
            {
                dataAtual = dataAtual.AddDays(-1);
            }

            List<DateTime> dataSemana = new List<DateTime>();

            // segunda
            dataSemana.Add(dataAtual);
            // domingo
            dataSemana.Add(dataAtual.AddDays(6));

            return dataSemana;
        }
    }
}
