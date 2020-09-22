using Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Business.Notifications
{
    /// <summary>
    /// Classe responsavel por portificar ao controller
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 21/09/2020
    /// </remarks>
    public class Notifier : INotifier
    {
        #region Attributes
        private List<Notification> _notifications;
        #endregion Attributes

        #region Methods
        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
        #endregion Methods
    }
}
