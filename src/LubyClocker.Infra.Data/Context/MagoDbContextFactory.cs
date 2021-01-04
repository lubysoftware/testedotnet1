using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LubyClocker.Infra.Data.Context
{
    public class LubyClockerDbContextFactory : IDesignTimeDbContextFactory<LubyClockerContext>
    {
        public LubyClockerContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder().Build();
            var optionsBuilder = new DbContextOptionsBuilder<LubyClockerContext>();
            optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=DB_LUBY;User Id=sa;Password=P#_LUBy@_", builder => { builder.MigrationsAssembly(typeof(LubyClockerContext).GetTypeInfo().Assembly.GetName().Name); });
            optionsBuilder.EnableSensitiveDataLogging();

            return new LubyClockerContext(optionsBuilder.Options, config, null);
        }
    }
}