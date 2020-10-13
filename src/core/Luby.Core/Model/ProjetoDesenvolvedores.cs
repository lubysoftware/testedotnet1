using System;

namespace Luby.Core.Model
{
    public class ProjetoDesenvolvedores
    {
        public DateTime? DtInicio { get; set; }
        public DateTime? DtFim { get; set; }

        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }

        public int DesenvolvedorId { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
    }
}