using apiLuby.Models;
using Microsoft.EntityFrameworkCore;

namespace apiLuby.Context
{
    public class MSSQLContext : DbContext
    {
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }

        public MSSQLContext(DbContextOptions<MSSQLContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>();

            modelBuilder.Entity<Appointment>()
                .HasOne(p => p.Developer)
                .WithMany(b => b.Appointments);

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Appointment)
                .WithOne(p => p.Project);
        } 
        
    }
}
