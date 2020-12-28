using Microsoft.Extensions.DependencyInjection;
using TesteLuby.Interfaces;
using TesteLuby.Services;

namespace TesteLuby.Shared.InjectionDependency
{
    public static class InjectionDependencyServices
    {
        public static void AddServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IDeveloperService, DeveloperService>();
            serviceDescriptors.AddScoped<IProjectService, ProjectService>();
            serviceDescriptors.AddScoped<IAppointmentService, AppointmentService>();
        }
    }
}
