using Business.Notifications;
using System.Collections.Generic;

namespace Business.Interfaces
{
    /// <summary>
    /// Interface de contrato do notificador
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public interface INotifier
    {
        #region Methods
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
        #endregion Methods
    }
}
