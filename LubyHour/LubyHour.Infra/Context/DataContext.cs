using LubyHour.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LubyHour.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
        }

        public DbSet<Management> Management { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Management>().ToTable("management");
            modelBuilder.Entity<Management>().Property(m=> m.Id);
            modelBuilder.Entity<Management>().Property(m => m.Developer).HasMaxLength(100).HasColumnType("varchar");
            modelBuilder.Entity<Management>().Property(m => m.StartTime);
            modelBuilder.Entity<Management>().Property(m => m.EndTime);
            modelBuilder.Entity<Management>().HasIndex(i => i.Developer);
        }

    }
}
