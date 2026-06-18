using Hours.Infra.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Hours.Infra.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {     
        public ContextDB CreateDbContext(string[] args)
        {
            var connectionsString = Connect.ConnectString();
            var optionsBuilder = new DbContextOptionsBuilder<ContextDB>();
            optionsBuilder.UseSqlServer(connectionsString);
            return new ContextDB(optionsBuilder.Options);
        }
    }
}