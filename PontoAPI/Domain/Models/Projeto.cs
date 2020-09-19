using System;

namespace PontoAPI.Domain.Models
{
    public class Projeto
    {
        public int ProjetoID { get; set; }

        public string NomeProjeto { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }
    }
}