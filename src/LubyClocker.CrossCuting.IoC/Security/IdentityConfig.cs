using System;
using LubyClocker.Domain.BoundedContexts.Users;
using LubyClocker.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace LubyClocker.CrossCuting.IoC.Security
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            // Identity
            services.AddIdentity<User, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<LubyClockerContext>()
                .AddDefaultTokenProviders();
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
        }
    }
}