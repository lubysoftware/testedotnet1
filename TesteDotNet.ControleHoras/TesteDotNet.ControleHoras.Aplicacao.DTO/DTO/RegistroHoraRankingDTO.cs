using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Aplicacao.DTO.DTO;

namespace Aplicacao.DTO.DTO
{
    public class RegistroHoraRankingDTO : IEntidadeDTO
    {
        public DateTime DataInicioSemana { get; set; }
        public DateTime DataFinalSemana { get; set; }
        public double TotalHorasTrabalhadas { get; set; }
        public Dictionary<int, double> DesenvolvedoresComMaisHoras { get; set; }

        public RegistroHoraRankingDTO()
        {
            DesenvolvedoresComMaisHoras = new Dictionary<int, double>();
        }
    }
}
