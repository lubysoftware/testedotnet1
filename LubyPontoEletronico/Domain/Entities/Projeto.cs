using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Projeto : Base
    {
        public string Nome { get; set; }
        public List<Pessoa> Pessoas { get; set; }
    }
}
