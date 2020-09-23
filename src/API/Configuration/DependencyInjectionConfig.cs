using API.Extensions;
using Business.Interfaces;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.Notifications;
using Business.Services;
using Data.Context;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

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

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<INotifier, Notifier>();

            //services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
