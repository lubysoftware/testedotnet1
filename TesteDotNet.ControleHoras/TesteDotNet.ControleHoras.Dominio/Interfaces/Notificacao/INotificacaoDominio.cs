using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Core.Interfaces.Notificacao
{
    public interface INotificacaoDominio
    {
        bool Validado();
        bool TemAviso();

        IEnumerable<string> ErroMensagens { get; }
        IEnumerable<string> AvisoMensagens { get; }

        void AddErro(string mensagem);
        void AddAviso(string mensagem);
    }
}
