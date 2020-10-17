using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.ControleHoras.Dominio.Entidades
{
    public class Projeto : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        public ICollection<Desenvolvedor> Desenvoledores { get; set; }
    }
}
