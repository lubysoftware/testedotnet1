using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteLuby.Models
{
    public class LançamentoHora
    {
        public int Id { get; set; }
        public DateTime HoraInicial { get; set; }
        public DateTime HoraFinal { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
    }
}
