using Microsoft.EntityFrameworkCore;
using TesteLuby.Data.Entities;
using TesteLuby.Data.Mapping;

namespace TesteLuby.Data.Context
{
    public class DbContextData : DbContext
    {
        public DbContextData(DbContextOptions<DbContextData> dbContextOptionsBuilder)
            : base(dbContextOptionsBuilder)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Developer> Developers { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>();
            modelBuilder.Entity<Developer>();
            modelBuilder.Entity<Appointment>();

            modelBuilder.ApplyConfiguration(new DbMappingProject());
            modelBuilder.ApplyConfiguration(new DbMappingDeveloper());
            modelBuilder.ApplyConfiguration(new DbMappingAppointment());
        }
    }
}
