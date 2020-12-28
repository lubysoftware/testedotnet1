using Microsoft.Extensions.DependencyInjection;
using test.domain.Interfaces.Services.DeveloperService;
using test.domain.Interfaces.Services.ProjectService;
using test.service.Services;

namespace test.application.Middlewares.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDeveloperService, DeveloperService>();
            serviceCollection.AddTransient<IProjectService, ProjectService>();
            serviceCollection.AddTransient<ILoginService, LoginService>();
            serviceCollection.AddTransient<IHoursService, HoursService>();


        }
    }
}
