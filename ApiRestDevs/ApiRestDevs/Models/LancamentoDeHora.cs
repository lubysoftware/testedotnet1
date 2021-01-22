using ApiRestDevs.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;

namespace ApiRestDevs.Models
{
    public class LancamentoDeHora
    {
        public LancamentoDeHora()
        {

        }

        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "Id do desenvolvedor é Obrigatório")]
        public int DesenvolvedorId { get; set; }

        [Required(ErrorMessage = "Id do projeto trabalhado é Obrigatório")]
        public int ProjetoTrabalhadoId { get; set; }

        [Required(ErrorMessage = "Data de Inicio é Obrigatória")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataDeInicio { get; set; }

        [Required(ErrorMessage = "Data Final é Obrigatória")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DataFinal { get; set; }

        [Required(ErrorMessage = "Quantidade de Horas trabalhadas é Obrigatória")]        
        public int QtdHorasTrabalhadas  { get; set; }

        [JsonIgnore]
        public Projeto ProjetoTrabalhado { get; set; }
        [JsonIgnore]
        public Desenvolvedor Desenvolvedor { get; set; }


        public static List<object> CalculaRankingDeHoras(DataContext context)
        {
            var cincoMaioresMedias = context.Desenvolvedores
                   .Select(x => x.LancamentoDeHoras.Select(y => y.QtdHorasTrabalhadas).Average())
                   .OrderByDescending(x => x)
                   .Take(5)
                   .ToList();

            var ranking = new List<object>();
            var contador = 1;

            foreach (var item in cincoMaioresMedias)
            {
                var desenvolvedor = context.Desenvolvedores
                    .FirstOrDefault(x => x.LancamentoDeHoras
                    .Select(y => y.QtdHorasTrabalhadas)
                    .Average() == item);

                ranking.Add(new { NomeDoDesenvolvedor = desenvolvedor.Nome, PosicaoDoRanking = contador++, MediaDeHoras = item });
            }
            return ranking;
        }
    }
}
