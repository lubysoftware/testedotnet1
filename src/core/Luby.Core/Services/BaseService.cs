namespace Luby.Core.Services
{
    using FluentValidation;
    using FluentValidation.Results;
    using Luby.Core.Interfaces.Services;
    using Luby.Core.Model;
    using Luby.Core.Notificacoes;

    public abstract class BaseService
    {
        private readonly INotificador _notifier;
        
        public BaseService(INotificador notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notificacao(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) 
            where TV : AbstractValidator<TE> 
            where TE : Entity
        {
            var validator = validation.Validate(entity);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}