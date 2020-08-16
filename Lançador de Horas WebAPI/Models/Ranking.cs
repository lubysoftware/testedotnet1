using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lançador_de_Horas_WebAPI.Models
{
    /// <summary>
    /// Ranking dos desenvolvedores
    /// </summary>
    [NotMapped]
    public class Ranking
    {
        /// Desenvolvedor
        [DisplayName("Nome do desenvolvedor")]
        public Desenvolvedor Desenvolvedor { get; set; }

        /// Total de horas da semana
        [DisplayName("Total de horas da semana")]
        [DataType(DataType.Time)]
        public TimeSpan MediaHoras { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Ranking()
        {
        }
    }
}