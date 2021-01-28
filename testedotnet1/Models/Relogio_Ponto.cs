using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testedotnet1.Models
{
    public class Relogio_Ponto
    {
        public int Id { get; set; }
        public int Id_Desenvolvedor { get; set; }
        public Desenvolvedor desenvolvedor { get; set; }
        public DateTime entrada { get; set; }
        public DateTime saida { get; set; }
    }
}
