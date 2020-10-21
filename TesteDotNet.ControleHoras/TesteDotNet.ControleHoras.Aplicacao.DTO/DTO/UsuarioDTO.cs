using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Aplicacao.DTO.DTO
{
    public class UsuarioDTO : IEntidadeDTO
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
    }
}
