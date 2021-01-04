using System;
using System.Net.Mime;
using LubyClocker.CrossCuting.Shared.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace LubyClocker.Api.Middlewares
{
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    
                    context.Response.StatusCode = contextFeature.Error is InvalidRequestException ? StatusCodes.Status400BadRequest : StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json;
                    await context.Response.WriteAsync(
                        JsonConvert.SerializeObject(new
                        {
                            error = contextFeature.Error.Message
                        })
                    );
                });
            });
        }
    }
}
