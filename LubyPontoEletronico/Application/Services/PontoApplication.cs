using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace Application.Services
{
    public class PontoApplication : ApplicationBase<Ponto, PontoDTO>, IPontoApplication
    {
        protected readonly IPontoService pontoService;
        public PontoApplication(IMapper map, IPontoService service) : base(map, service)
        {
            pontoService = service;
        }

        public List<RankingMediaPontoDTO> GetMediaPonto()
        {
            var result = pontoService.GetMediaPonto();
            List<RankingMediaPontoDTO> listaRetorno = new List<RankingMediaPontoDTO>();
            result.ForEach(x =>
            {
                TimeSpan horasDaSemana = new TimeSpan();
                x.Pontos.Where(y => y.DataFim != null).ToList().ForEach(z =>
                {
                    var time = Convert.ToDateTime(z.DataFim).TimeOfDay - z.DataInicio.TimeOfDay;
                    horasDaSemana += time;
                });


                listaRetorno.Add(new RankingMediaPontoDTO
                {
                    IdPessoa = x.Id,
                    Media = Convert.ToDouble(((horasDaSemana / 7).TotalHours).ToString("F")),
                    Nome = x.Nome
                });
            });

            return listaRetorno.OrderByDescending(x => x.Media).Take(5).ToList();
        }
    }
}
