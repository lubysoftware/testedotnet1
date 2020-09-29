using LTS.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LTS.Infra.Context
{
    public class LubyContext : IdentityDbContext
    {
        private readonly string _connString = "Server=localhost\\SQLEXPRESS;User Id=humbe;Database=Luby;Trusted_Connection=True;MultipleActiveResultSets=true";

        public DbSet<Developer> Developer { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }
        public DbSet<DeveloperProject> DeveloperProject { get; set; }


        public LubyContext(DbContextOptions<LubyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connString,
                sqlOptions => sqlOptions.EnableRetryOnFailure(3));
        }
    }
}
