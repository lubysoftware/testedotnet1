using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class PessoaDTO : BaseDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int IdProjeto { get; set; }
        public string TipoPessoa { get; set; }
    }
}
