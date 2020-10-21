using Aplicacao.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacao.Principal
{
    public interface ICadastroSalvarResultado
    {
        IEntidadeDTO EntidadeDTO { get; }
        IEnumerable<string> ErroMensagem { get; }
        IEnumerable<string> AvisoMensagem { get; }
        string MensagemErro400SalvandoCadastro();
    }
}
