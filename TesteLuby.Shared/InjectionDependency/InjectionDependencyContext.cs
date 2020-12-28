using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TesteLuby.Data.Context;

namespace TesteLuby.Shared.InjectionDependency
{
    public static class InjectionDependencyContext
    {
        public static void AddContext(this IServiceCollection serviceDescriptors, string connection)
        {
            serviceDescriptors.AddDbContext<DbContextData>(
                              options => options.UseSqlServer(connection));
        }
    }
}
