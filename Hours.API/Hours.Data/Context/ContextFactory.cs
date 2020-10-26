using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Hours.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        private readonly IConfiguration _configuration;

        public ContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ContextDB CreateDbContext(string[] args)
        {
            var connectionsString = _configuration.GetConnectionString("DefaultConnection");
            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
            optionsBuilder.UseSqlServer(connectionsString);
            return new ContextDB(optionsBuilder.Options);
        }
    }
}
