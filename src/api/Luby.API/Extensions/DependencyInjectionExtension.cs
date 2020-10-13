namespace Luby.API.Extensions
{
    using Luby.Core.Interfaces.Repositories;
    using Luby.Core.Interfaces.Services;
    using Luby.Core.Notificacoes;
    using Luby.Core.Services;
    using Luby.Data.Context;
    using Luby.Data.Repository;
    using Microsoft.Extensions.DependencyInjection;

    public static class DepedencyInjection
    {
        /// <summary>
        /// Método de extensão para resolver todas as dependencias
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<LubyContext>();
            services.AddScoped<IDesenvolvedorRepository, DesenvolvedorRepository>();
            services.AddScoped<IDesenvolvedorService, DesenvolvedorService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IProjetoService, ProjetoService>();
            
            return services;
        }
    }
}