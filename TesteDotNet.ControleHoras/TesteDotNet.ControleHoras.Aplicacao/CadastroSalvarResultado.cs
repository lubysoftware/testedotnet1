using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aplicacao.Principal
{
    public class CadastroSalvarResultado : ICadastroSalvarResultado
    {
        public IEntidadeDTO EntidadeDTO { get; }
        public IEnumerable<string> ErroMensagem { get; }
        public IEnumerable<string> AvisoMensagem { get; }
               

        public CadastroSalvarResultado(IEntidadeDTO entidadeDTO, IEnumerable<string> avisoMensagem, IEnumerable<string> erroMensagem)
        {
            EntidadeDTO = entidadeDTO;
            AvisoMensagem = avisoMensagem;
            ErroMensagem = erroMensagem;
        }

        public string MensagemErro400SalvandoCadastro()
        {
            return $"Um ou mais problemas foram encontrados. Verifique: \n{ string.Join(";\n", ErroMensagem.ToArray())}";
        }
    }
}
