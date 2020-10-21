using Dominio.Core.Interfaces.Notificacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Principal.Notificacao
{
    public class NotificacaoDominio : INotificacaoDominio
    {
        private readonly List<string> _erroMensagens = new List<string>();
        public IEnumerable<string> ErroMensagens => _erroMensagens;

        private readonly List<string> _avisoMensagens = new List<string>();
        public IEnumerable<string> AvisoMensagens => _avisoMensagens;

        public void AddAviso(string mensagem)
        {
            _avisoMensagens.Add(mensagem);
        }

        public void AddErro(string mensagem)
        {
            _erroMensagens.Add(mensagem);
        }

        public bool TemAviso()
        {
            return _avisoMensagens.Any();
        }

        public bool Validado()
        {
            if (_erroMensagens.Any())
                throw new ArgumentException(string.Join(";\n", _erroMensagens.ToArray()));

            return true;
        }
    }
}
