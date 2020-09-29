using LTS.API.Authorizations;
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
            
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            
        }
    }
}
