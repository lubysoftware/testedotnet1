using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Notifications;
using Business.Services;
using Data.Context;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace API.Configuration
{
    public static  class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MyDbContext>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ILaunchTimeRepository, LaunchTimeRepository>();

            services.AddScoped<IDeveloperService, DeveloperService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ILaunchTimeService, LaunchTimesService>();

            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
