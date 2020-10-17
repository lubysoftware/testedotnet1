using System;
using System.Collections.Generic;
using System.Text;

namespace TesteDotNet.ControleHoras.Dominio.Entidades
{
    public class Desenvolvedor : Entidade
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public int ProjetoId { get; set; }
        public virtual Projeto Projeto { get; set; }
    }
}
