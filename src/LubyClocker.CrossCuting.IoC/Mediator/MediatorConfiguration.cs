using System;
using LubyClocker.Application.BoundedContexts.Users.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LubyClocker.CrossCuting.IoC.Mediator
{
    public static class MediatorConfiguration
    {
        public static void AddMediatorConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(config => config.AsScoped(), AppDomain.CurrentDomain.Load("LubyClocker.Application"));
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}