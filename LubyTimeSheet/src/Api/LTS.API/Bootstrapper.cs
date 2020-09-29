using LTS.API.Authorizations;
using LTS.Domain.Handlers;
using LTS.Domain.Interfaces;
using LTS.Domain.Services;
using LTS.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LTS.API
{
    public static class Bootstrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthUser, AuthUser>();

            RegisterDomainServices(services);
            RegisterRepositories(services);
            RegisterHandlers(services);
        }

        private static void RegisterHandlers(IServiceCollection services)
        {
            services.AddScoped<DeveloperHandler>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IDeveloperService, DeveloperService>();
        }
    }
}
