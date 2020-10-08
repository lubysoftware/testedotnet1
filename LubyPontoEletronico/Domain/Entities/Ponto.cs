using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Ponto : Base
    {
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int IdPessoa { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}
