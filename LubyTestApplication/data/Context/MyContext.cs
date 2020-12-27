using Microsoft.EntityFrameworkCore;
using test.data.Map;
using test.domain.Entities;

namespace test.data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Hours> Hours { get; set; }



        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Project>(new ProjectMap().Configure);
            modelBuilder.Entity<Developer>(new DeveloperMap().Configure);
            modelBuilder.Entity<Hours>(new HoursMap().Configure);

        }

    }
}
