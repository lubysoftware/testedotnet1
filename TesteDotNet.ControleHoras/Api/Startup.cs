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
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Repositorios;
using TesteDotNet.ControleHoras.Dominio.Core.Interfaces.Servicos;
using TesteDotNet.ControleHoras.Dominio.Servicos.Servicos;

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

            services.AddScoped<IRepositorioDesenvolvedor, RepositorioDesenvolvedor>();
            services.AddScoped<IServicoDesenvolvedor, ServicoDesenvolvedor>();
            services.AddScoped<IAppServicoDesenvolvedor, AppServicoDesenvolvedor>();
            //services.AddScoped<IAppServicoProjeto, AppServicoProjeto>();
            //services.AddScoped<IAppServicoRegistroHoras, AppServicoRegistroHora>();
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
    }
}
