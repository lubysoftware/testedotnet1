namespace Luby.Core.Notificacoes
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface para gerencia as notificaçoes
    /// </summary>
    public interface INotificador
    {
        /// <summary>
        /// Verifica se existem notificaçoes
        /// </summary>
        /// <returns></returns>
        bool HasNotification();

        /// <summary>
        /// Lista todas as Notificaoes existentes
        /// </summary>
        /// <returns></returns>
        List<Notificacao> GetNotificacoes();

        /// <summary>
        /// Adiciona uma Notificacao na Lista de Notificacoes
        /// </summary>
        /// <param name="notificacao"></param>
        void Handle(Notificacao notificacao);
    }
}
