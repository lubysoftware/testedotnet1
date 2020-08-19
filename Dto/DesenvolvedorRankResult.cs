using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancamentoHorasAPI.Dto
{
    public class DesenvolvedorRankResult
    {
        public int DesenvolvedorId { get; set; }
        public string Nome { get; set; }
        public TimeSpan HorasTrabalhadas { get; set; }
    }
}
