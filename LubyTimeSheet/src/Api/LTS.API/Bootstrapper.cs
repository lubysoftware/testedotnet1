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
            services.AddScoped<ProjectHandler>();
            services.AddScoped<TimeSheetHandler>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITimeSheetRepository, TimeSheetRepository>();
        }

        private static void RegisterDomainServices(IServiceCollection services)
        {
            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITimeSheetService, TimeSheetService>();
        }
    }
}
