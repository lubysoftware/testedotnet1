using Business.Interfaces;
using Business.Notificacoes;
using Business.Services;
using Data.Context;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Extensoes;

namespace WebApplication.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApiDbContext>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IDesenvolvedorRepository, DesenvolvedorRepository>();
            services.AddScoped<IDesenvolvedorService, DesenvolvedorService>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<ILancamentoDeHoraRepository, LancamentoDeHoraRepository>();
            services.AddScoped<ILancamentoDeHoraService, LancamentoDeHoraService>();
            services.AddScoped<IUser, AspNetUser>();
            return services;
        }
    }
}