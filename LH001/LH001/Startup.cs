using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LH001.Contexto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LH001
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
            services.AddControllers();
            var connection = @"Data Source=server-jovemdeelite.database.windows.net;Initial Catalog=LH001;Persist Security Info=True;User ID=JovemDeElite;Password=pwd_LH001;";
            //services.AddDbContext<BdContext>(options => options.UseSqlServer(connection));
            services.AddDbContext<BdContext>(options =>
            {
                options.UseSqlServer(connection,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            });
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddRazorPages();
    //.AddNewtonsoftJson(options =>
    //{
    //    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    //    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    //})
    //.AddSessionStateTempDataProvider();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
