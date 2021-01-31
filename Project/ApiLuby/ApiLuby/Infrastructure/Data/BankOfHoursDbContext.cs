using ApiLuby.Business.Entities;
using ApiLuby.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiLuby.Infrastructure.Data
{
    public class BankOfHoursDbContext : DbContext
    {
        public BankOfHoursDbContext(DbContextOptions<BankOfHoursDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BankOfHoursMapping());
            modelBuilder.ApplyConfiguration(new DeveloperMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Developer> Developer { get; set; }
        public DbSet<BankOfHours> BankOfHours { get; set; }
    }
}
