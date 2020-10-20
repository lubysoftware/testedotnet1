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
using Aplicacao.Principal.Interfaces;
using Aplicacao.Principal.Servicos;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Dominio.Principal.Interfaces.Repositorios;
using Dominio.Principal.Interfaces.Servicos;
using Dominio.Servicos.Servicos;
using Infra.DTO.Mapeamento.Map;
using Microsoft.AspNetCore.Authorization;

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

            ConfigureAuthenticationJwt(services);
            ConfigureServicesEx(services);
            ConfigureMappers(services);
                        
            services.AddMvc();

            //Registrando o swagger.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "WebApi-RegistroHoras",
                    Version = "v1",
                    Contact = new OpenApiContact { Name = "Vinícius Rafael Migliorança", Email = "vrmvinicius@gmail.com" }
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

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi-RegistroHoras V1");
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

            services.AddScoped<IAppServicoRegistroHorasRanking, AppServicoRegistroHoraRanking>();

            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IServicoUsuario, ServicoUsuario>();
            services.AddScoped<IAppServicoAutenticacao, AppServicoAutenticacao>();
        }

        private void ConfigureMappers(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperDesenvolvedor());
                mc.AddProfile(new MapperProjeto());
                mc.AddProfile(new MapperRegistroHora());
                mc.AddProfile(new MapperUsuario());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);
        }

        private void ConfigureAuthenticationJwt(IServiceCollection services)
        {
            //Se não colocar o trecho abaixo somente retorna o erro de falha na validação do token '401'.
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });

            var key = Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}
