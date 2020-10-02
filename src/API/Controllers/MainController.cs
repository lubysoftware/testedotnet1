using Business.Interfaces;
using Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace API.Controllers
{

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly IUser AppUser;

        protected Guid UsuarioId { get; set; }
        protected bool UsuarioAutenticado { get; set; }

        public MainController(INotifier notifier, IUser user)
        {
            _notifier = notifier;
            AppUser = user;

            if (AppUser.IsAuthenticated())
            {
                UsuarioId = AppUser.GetUserId();
                UsuarioAutenticado = true;
            }
        }

        protected bool OperationValid()
        {
            return !_notifier.HasNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationValid())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(x => x.Message)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
                NotifyErrorModelInvalid(modelState);

            return CustomResponse();
        }

        protected void NotifyErrorModelInvalid(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(error => error.Errors);

            foreach(var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;

                NotifyError(errorMessage);
            }
        }

        protected void NotifyError(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}
