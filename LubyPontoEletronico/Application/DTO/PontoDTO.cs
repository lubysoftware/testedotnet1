using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PontoDTO : BaseDTO
    {
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int IdPessoa { get; set; }
    }
}
