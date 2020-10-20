using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TimeSheetManager.Domain.Entities.DeveloperNS;
using TimeSheetManager.Domain.Entities.Project;
using TimeSheetManager.Domain.Entities.TimeSheetNS;

namespace TimeSheetManager.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}