using System;

namespace PontoAPI.Domain.Models
{
    public class Lancamento
    {
        public int LancamentoID { get; set; }

        public Desenvolvedor Desenvolvedor { get; set; }

        public Projeto Projeto { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime? HoraFim { get; set; }
    }
}