using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteApi.Models
{
    public class Desenvolvedor
    {
        public string Nome { get; set; }

        public Desenvolvedor(string nome) // Construtor
        {
            this.Nome = nome;
        }
    }
}