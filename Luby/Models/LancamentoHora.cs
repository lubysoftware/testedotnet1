using Luby.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Luby.Models
{
    public class LancamentoHora : Entity<int>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
        public Projeto Projeto { get; set; }
    }
}
