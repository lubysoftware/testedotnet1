using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace API.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate request)
        {
            _next = request;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            exception.Ship(httpContext);
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
