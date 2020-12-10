using System;

namespace Business
{
    public class LancamentoDeHora : Entity
    {
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFim { get; set; }
        public DateTime DataCadastro { get; set; }

        // Ef Relations
        public Desenvolvedor Desenvolvedor { get; set; }
        public Projeto Projeto { get; set; }
    }
}