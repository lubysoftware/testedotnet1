using LTS.API;
using LTS.API.Configuration.AutoMapper;
using LTS.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LTS.Test
{
    public class LubyIntegrationTestBase
    {
        private IServiceCollection _services { get; }
        protected ServiceProvider _serviceProvider { get; }
        protected LubyContext _context { get; set; }

        public LubyIntegrationTestBase()
        {
            var options = new DbContextOptionsBuilder<LubyContext>();
            _services = new ServiceCollection();

            _services.AddSetupAutoMapper();

            _services.AddDbContext<LubyContext>();

            _services.AddEntityFrameworkInMemoryDatabase().AddDbContext<LubyContext>((_serviceProvider, options) =>
            {
                options.UseInMemoryDatabase(Guid.NewGuid().ToString().Replace("-", ""))
                .UseInternalServiceProvider(_serviceProvider);
            });
               
            _services.RegisterServices();
            _serviceProvider = _services.BuildServiceProvider();
            _context = _serviceProvider.GetRequiredService<LubyContext>();
        }
        protected T Resolve<T>() => _serviceProvider.GetRequiredService<T>();
        protected T ResolveCollection<T>() => ActivatorUtilities.CreateInstance<T>(_serviceProvider);

        protected void PersistEntities(params object[] entities)
        {
            foreach (var entity in entities)
            {
                _context.Add(entity);
            }
            _context.SaveChanges();
        }
    }
}
