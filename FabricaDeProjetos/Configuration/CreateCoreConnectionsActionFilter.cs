using Core.Core;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FabricaDeProjetos.Controllers.Base;

namespace FabricaDeProjetos.Configuration
{
    public class CreateCoreConnectionsActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.Controller is FabricaDeProjetosControllerBase controller)
            {
                controller.CreateCoreConnections();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
