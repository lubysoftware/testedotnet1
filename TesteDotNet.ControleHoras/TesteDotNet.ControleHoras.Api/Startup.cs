using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infra.Dados.Base;
using Infra.Dados.Base.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteDotNet.ControleHoras.Aplicacao.Interfaces;
using TesteDotNet.ControleHoras.Aplicacao.Servicos;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Servicos.Servicos;
using TesteDotNet.ControleHoras.DTO.Mapeamento.Map;
using TesteDotNet.ControleHoras.Dominio.Interfaces.Servicos;
using Dominio.Core.Interfaces.Notificacao;
using Dominio.Principal.Notificacao;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContexto>(opt => opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers()
                    .AddNewtonsoftJson();

            ConfigureServicesEx(services);
            ConfigureMappers(services);
                        
            services.AddMvc();
        }
                
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureServicesEx(IServiceCollection services)
        {
            services.AddScoped<INotificacaoDominio, NotificacaoDominio>();

            services.AddScoped<IRepositorioDesenvolvedor, RepositorioDesenvolvedor>();
            services.AddScoped<IServicoDesenvolvedor, ServicoDesenvolvedor>();
            services.AddScoped<IAppServicoDesenvolvedor, AppServicoDesenvolvedor>();

            services.AddScoped<IRepositorioProjeto, RepositorioProjeto>();
            services.AddScoped<IServicoProjeto, ServicoProjeto>();
            services.AddScoped<IAppServicoProjeto, AppServicoProjeto>();

            services.AddScoped<IRepositorioRegistroHora, RepositorioRegistroHora>();
            services.AddScoped<IServicoRegistroHora, ServicoRegistroHora>();
            services.AddScoped<IAppServicoRegistroHoras, AppServicoRegistroHora>();
        }

        private void ConfigureMappers(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperDesenvolvedor());
                mc.AddProfile(new MapperProjeto());
                mc.AddProfile(new MapperRegistroHora());                
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }
    }
}
