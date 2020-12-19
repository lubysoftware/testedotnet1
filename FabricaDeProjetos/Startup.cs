using Core.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FabricaDeProjetos.Core;
using Dommel;
using Dapper.FluentMap.Dommel.Resolvers;
using FabricaDeProjetos.Configuration;
using Microsoft.OpenApi.Models;

namespace FabricaDeProjetos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            DommelMapper.SetTableNameResolver(new DommelTableNameResolver());
            Configuration = configuration;
            StaticConfig = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration StaticConfig { get; private set; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddScoped<ITokenServiceCore, TokenServiceCore>();

            DependencyInjection.AddDependencies(ref services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "testedotnet1", Version = "v1" });
            });

            //Connection DB
            var connectionString = Configuration.GetConnectionString("FabricaDeProjetosDB");

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            })
                // Habilita a possibilidade de passar o Accept XML no Header (transforma retorno em XML)
                .AddXmlSerializerFormatters();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            //JWT 
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("Token").Value);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
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


            // Inicia as conexões dos core's no controller chamado
            services.AddTransient<CreateCoreConnectionsActionFilter>();
            services.AddMvc(options =>
            {
                options.Filters.AddService<CreateCoreConnectionsActionFilter>();
            });


        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "testedotnet1 v1"));

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
