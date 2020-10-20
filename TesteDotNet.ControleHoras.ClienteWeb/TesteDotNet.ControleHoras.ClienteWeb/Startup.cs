using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TesteDotNet.ControleHoras.ClienteWeb.Data;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Infrastructure.Utility;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Entidades;
using TesteDotNet.ControleHoras.ClienteWeb.Data.Servicos.Interfaces;

namespace TesteDotNet.ControleHoras.ClienteWeb
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
            services.AddRazorPages();
            services.AddServerSideBlazor();

            ConfigureServicesEx(services);

            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);
        }

        private void ConfigureServicesEx(IServiceCollection services)
        {
            services.AddSingleton<HttpClient>();
            services.AddScoped<IDesenvolvedorServico, DesenvolvedorServico>();
            services.AddScoped<IProjetoServico, ProjetoServico>();            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
