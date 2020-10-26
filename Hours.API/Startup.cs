using AutoMapper;
using FluentValidation.AspNetCore;
using Hours.API.Extensions;
using Hours.Application.Mappers;
using Hours.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Hours.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterInterface();
            services.AddAutoMapper(typeof(CoreProfile));
            ConfigureRepository.ConfigureDepedenciesRepository(services);
       
            services.AddControllers().AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Teste Luby",
                    Description = "Projeto desenvolvido com arquitetura DDD.",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name= "Ronaldo Bruno de Souza Santos",
                        Email= "ronaldobrunoss@hotmail.com"                        
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Luby - Ronaldo Bruno");
                c.RoutePrefix = string.Empty;            
            });          

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste Luby - Ronaldo Bruno");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
