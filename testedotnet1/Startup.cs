using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using testedotnet1.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace testedotnet1
{
    public class Startup
    {
        public IConfiguration Configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<Contexto>(options => options.UseSqlServer(Configuration.GetConnectionString("Data Source=DESKTOP-5H2IR2A; Initial Catalog=RelogioBancoHoras;Trusted_Connection=True;MultipleActiveResultSets=true")));
            services.AddDbContext<Contexto>(options => options.UseSqlServer("Data Source=DESKTOP-5H2IR2A; Initial Catalog=RelogioBancoHoras;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
