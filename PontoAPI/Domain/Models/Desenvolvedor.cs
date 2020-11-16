using System;

namespace PontoAPI.Domain.Models
{
    public class Desenvolvedor
    {
        public int DesenvolvedorID { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}