using Microsoft.Extensions.DependencyInjection;

namespace LTS.API.Configuration.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static void AddSetupAutoMapper(this IServiceCollection services)
        {
            var configuration = AutoMapperConfig.RegisterMappings();

            services.AddScoped(x => configuration.CreateMapper());
        }
    }
}
