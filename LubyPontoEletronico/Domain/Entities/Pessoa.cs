using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Pessoa : Base
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdProjeto { get; set; }
        public string TipoPessoa { get; set; }

        public Projeto Projeto { get; set; }
        public List<Ponto> Pontos { get; set; }
    }
}
