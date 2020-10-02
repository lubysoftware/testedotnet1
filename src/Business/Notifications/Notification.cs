namespace Business.Notifications
{
    /// <summary>
    /// Classe de notificação, armazena uma mensagem para ser notificada
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public class Notification
    {
        #region Properties
        public string Message { get; }
        #endregion Properties

        #region Constructor
        public Notification(string message)
        {
            Message = message;
        }
        #endregion Constructor
    }
}
