using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using testedotnet1.Entities;

namespace testedotnet1.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // nõ conseguiu logar
                context.Result = new JsonResult(new { message = "Não Autorizado." }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}