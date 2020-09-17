using LubyClocker.Api.Binders;
using LubyClocker.CrossCuting.IoC.Database;
using LubyClocker.CrossCuting.IoC.Mediator;
using LubyClocker.CrossCuting.IoC.Security;
using LubyClocker.CrossCuting.IoC.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LubyClocker.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddControllers()
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.Converters.Add(new StringEnumBinder());
                });
            
            // HttpContextAccessor
            services.AddHttpContextAccessor();

            services.AddJwtTokenSetup(Configuration);
            services.AddDatabaseConfiguration(Configuration);
            services.AddOpenApiConfiguration();
            services.AddIdentityConfiguration();
            services.AddMediatorConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                s.DisplayRequestDuration();
                s.DisplayOperationId();
                s.EnableValidator();
                s.EnableDeepLinking();
                s.ShowExtensions();

                s.RoutePrefix = "swagger";
                s.DocumentTitle = "Luby Clocker Api";
            });
        }
    }
}