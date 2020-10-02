using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

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
        [System.Text.Json.Serialization.JsonIgnore]
        public TimeSpan MediaHoras { get; set; }

        /// Atributo para serializar JSON
        public string MediaHorasString
        {
            get => MediaHoras.ToString();
            set => MediaHoras = TimeSpan.Parse(value);
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public Ranking()
        {
        }
    }
}