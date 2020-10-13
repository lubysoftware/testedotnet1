namespace Luby.Core.Notificacoes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Classe para gerencia as Notificaçoes
    /// </summary>
    public class Notificador : INotificador
    {
        private List<Notificacao> _notificacoes;
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public List<Notificacao> GetNotificacoes()
        {
            return _notificacoes;
        }

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public bool HasNotification()
        {
            return _notificacoes.Any();
        }
    }
}
