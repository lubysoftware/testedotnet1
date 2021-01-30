using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace testedotnet1.Models
{
    public class Desenvolvedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Desenvolvedor (string nome)
        {
            this.Nome = nome;
        }
    }
}
