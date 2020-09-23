using API.Configuration;
using AutoMapper;
using Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(optionsAction: options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString(name: "DefaultConnection"));
            });

            services.AddIdentityConfiguration(Configuration);

            services.AddAutoMapper(typeof(Startup));


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.ResolveDependencies();

            // services.AddSwaggerConfig();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API teste", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();

            // app.UseSwaggerConfig(provider);

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });
        }
    }
}
