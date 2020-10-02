using Lançador_de_Horas_WebAPI.Context;
using Lançador_de_Horas_WebAPI.Models;
using Lançador_de_Horas_WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Globalization;
using System.Data.Common;
using Microsoft.AspNetCore.Localization;

namespace Lançador_de_Horas_WebAPI
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
            services.AddControllersWithViews();
            services.AddTransient<RankingService>()
                .AddTransient<DesenvolvedorService>()
                .AddTransient<RegistroDeHorasService>()
                .AddTransient<ProjetoService>();

            //Serviço para acessar o contexto do banco de dados
            services.AddDbContext<LancadorContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            //Serviço do Swagger
            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo
                   {
                       Version = "v1",
                       Title = "Lançador de horas Luby",
                       Description = "Aplicação para teste da Luby",
                       Contact = new OpenApiContact
                       {
                           Name = "Josimar Vieira",
                           Email = "josimarsv@outlook.com",
                           Url = new Uri("https://linkedin.com/in/josimarsvieira"),
                       },
                       License = new OpenApiLicense
                       {
                           Name = "Versão para testes",
                       }
                   });

                   c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                   {
                       Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                       Name = "Authorization",
                       In = ParameterLocation.Header,
                       Type = SecuritySchemeType.ApiKey,
                       Scheme = "Bearer"
                   });

                   c.AddSecurityRequirement(new OpenApiSecurityRequirement()
               {
                   {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                    Array.Empty<string>()
                   }
               });

                   var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                   var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                   c.IncludeXmlComments(xmlPath);
               });

            //Serviço para autenticação do Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<LancadorContext>()
                .AddDefaultTokenProviders();

            //Serviço para autenticação via JWT
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
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                        ClockSkew = TimeSpan.Zero
                    };
                });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //Habilita o middleware para o serviço gerar um Swagger como um Json endpoint.
            app.UseSwagger();

            //Habilita o middleware para o serviço Swagger-UI(HTML, JS, CSS, etc.),
            //Especifica um Swagger Json endpont.
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lançador de Horas");
                }
            );

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Habilita o servidor a usar autenticação
            app.UseAuthentication();

            //Habilita o servidor a usar autorização de acesso
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}