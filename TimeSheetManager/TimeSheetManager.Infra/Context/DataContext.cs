using System.Reflection;
using Microsoft.EntityFrameworkCore;
using TimeSheetManager.Domain.Entities.Developer;
using TimeSheetManager.Domain.Entities.Project;

namespace TimeSheetManager.Infra.Context {
    public class DataContext : DbContext {
        public DataContext(DbContextOptions options) : base(options){

        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder){
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}