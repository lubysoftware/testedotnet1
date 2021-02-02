using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApi.Models
{
    public class HoraTrabalhada
    {
        public Desenvolvedor Desenvolvedor { get; set; }
        public int DesenvolvedorId { get; set; }
        public Projeto Projeto { get; set; }
        public int ProjetoId { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtFim { get; set; }
        
    }
}