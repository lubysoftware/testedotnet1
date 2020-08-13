using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Models
{
    public class RegistroDeHoras
    {
        public int ID { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public TimeSpan TotalPausa { get; private set; }
        public TimeSpan TotalHoras { get; private set; }
        public Desenvolvedor Desenvolvedor { get; set; }
        public Projeto Projeto { get; set; }

        /// <summary>
        /// Construtor da Classe
        /// </summary>
        public RegistroDeHoras()
        {
        }

        /// <summary>
        /// Metodo para calculo das horas totais do dia
        /// </summary>
        public void CalculaTotalHoras()
        {
            TotalHoras = DataFim.Subtract(DataInicio);
        }

        /// <summary>
        /// Metodo para adicionar tempo de pausa
        /// </summary>
        /// <param name="pausa"></param>
        public void AdicionaPausa(TimeSpan pausa)
        {
            TotalPausa += pausa;
        }
    }
}