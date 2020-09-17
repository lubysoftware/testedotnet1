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
        }
    }
}