using TimeManager.Application.Common.Interfaces;
using TimeManager.Infrastructure.Identity;
using TimeManager.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TimeManager.Domain.Projects;
using TimeManager.Infrastructure.Domain.Projects;
using TimeManager.Domain.Developers;
using TimeManager.Infrastructure.Domain.Developers;
using TimeManager.Domain.Projects.ProjectMembers;
using TimeManager.Infrastructure.Domain.Projects.ProjectMembers;

namespace TimeManager.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseInMemoryDatabase("TimeManagerDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IDeveloperRepository, DeveloperRepository>();
            services.AddScoped<IProjectMemberRepository, ProjectMemberRepository>();

                services.AddDefaultIdentity<ApplicationUser>()
                    .AddEntityFrameworkStores<ApplicationDbContext>();
            
            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            return services;
        }
    }
}
