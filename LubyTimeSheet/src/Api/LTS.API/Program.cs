using LTS.API.Authorizations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NetDevPack.Identity.Jwt;

namespace LTS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateHostBuilder(args).Build();

            using (var scope = webHost.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var signInManager = scope.ServiceProvider.GetRequiredService<SignInManager<IdentityUser>>();
                var options = scope.ServiceProvider.GetRequiredService<IOptions<AppJwtSettings>>();

                var authUser = new AuthUser(userManager, signInManager, options);
                authUser.CreateDefaultUserAdmin("admin@admin.com", "admin").Wait();
            }

            webHost.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
