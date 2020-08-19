using System;

namespace LancamentoHorasAPI.Models
{
    public class Lancamento
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public Desenvolvedor Desenvolvedor { get; set; }
        public int DesenvolvedorId { get; set; }

    }
}