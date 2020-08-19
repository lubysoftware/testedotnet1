using System;

namespace LancamentoHorasAPI.Dto
{
    public class LancamentoPost
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int DesenvolvedorId { get; set; }
    }
}