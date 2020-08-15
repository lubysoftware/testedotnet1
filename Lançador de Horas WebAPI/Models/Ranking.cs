using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Models
{
    [NotMapped]
    public class Ranking
    {
        [DisplayName("Nome do desenvolvedor")]
        public string Nome { get; set; }

        [DisplayName("Total de horas da semana")]
        [DataType(DataType.Time)]
        public TimeSpan MediaHoras { get; set; }

        public Ranking()
        {
        }
    }
}