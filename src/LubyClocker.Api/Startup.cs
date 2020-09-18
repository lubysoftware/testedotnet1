using LubyClocker.Api.Binders;
using LubyClocker.Api.Middlewares;
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
            
            services.AddDatabaseConfiguration(Configuration);
            services.AddOpenApiConfiguration();
            services.AddIdentityConfiguration();
            services.AddJwtTokenSetup(Configuration);
            services.AddMediatorConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandlerMiddleware();
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });
            app.UseAuthentication();
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