using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TimeManager.Domain.Projects;
using TimeManager.Domain.Developers;
using TimeManager.Domain.Developers.TimeReports;
using TimeManager.Application.Common.Interfaces;

namespace TimeManager.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<TimeReport> TimeReports { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
