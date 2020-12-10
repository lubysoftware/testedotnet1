using System;

namespace Business
{
    public class Desenvolvedor : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}