using Business.Interfaces;
using Business.Models;
using Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Services
{
    /// <summary>
    /// Classe abstrata base para a implementaçõea dos serviços
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 19/09/2020
    /// </remarks>
    public abstract class BaseService
    {
        #region Atributtes
        private readonly INotifier _notifier;
        #endregion Atributtes

        #region Constructor
        protected BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }
        #endregion Constructor

        #region Methods
        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                Notify(error.ErrorMessage);
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV: AbstractValidator<TE> where TE: Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid)
                return true;

            Notify(validator);

            return false;
        }
        #endregion Methods
    }
}
