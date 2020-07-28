using Lubby.Data.Mapping;
using Lubby.Domain.Root;
using Lubby.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Lubby.Data
{
    public class LubbyContext : DbContext
    {

        public DbSet<Project> ProjectSet { get; set; }
        public DbSet<Developer> DeveloperSet{ get; set; }
        public DbSet<Work> WorkSet { get; set; }


        public LubbyContext(DbContextOptions option) :base(option) {}
        public LubbyContext(){}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Domain.Resource.ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DeveloperMapping());
            modelBuilder.ApplyConfiguration(new ProjectMapping());
            modelBuilder.ApplyConfiguration(new WorkMapping());
        }


    }
}
