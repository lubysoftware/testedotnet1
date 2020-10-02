using System;

namespace LancamentoHorasAPI.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Projeto() { }

        public Projeto(string nome)
        {
            Nome = nome;
        }
    }
}