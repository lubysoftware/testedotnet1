namespace Luby.API.Controllers
{
    using System.Linq;
    using Luby.Core.Notificacoes;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly INotificador _notificador;
        
        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

       protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotifierErroModelInvalid(modelState);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationIsValid())
                return Ok(new
                {
                    success = true,
                    data = result
                });

            return BadRequest(new
            {
                success = false,
                errors = _notificador.GetNotificacoes().Select(m => m.Message)
            });
        }

        protected bool OperationIsValid()
        {
            return !_notificador.HasNotification();
        }

        protected void NotifierErroModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifierError(errorMessage);
            }
        }

        protected void NotifierError(string errorMessage)
        {
            _notificador.Handle(new Notificacao(errorMessage));
        }
    }
}