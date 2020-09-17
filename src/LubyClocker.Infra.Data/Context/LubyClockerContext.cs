using System;
using Humanizer;
using LubyClocker.Domain.BoundedContexts.Developers;
using LubyClocker.Domain.BoundedContexts.Projects;
using LubyClocker.Domain.BoundedContexts.Users;
using LubyClocker.Infra.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LubyClocker.Infra.Data.Context
{
    public sealed class LubyClockerContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ILogger<LubyClockerContext> Logger { get; private set; }
        public IConfiguration Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(Configuration.GetValue<string>("DB_CONNECTION_STRING"));
        }

        private LubyClockerContext(DbContextOptions options, IConfiguration config, ILogger<LubyClockerContext> logger) : base(options)
        {
            Configuration = config;
            Logger = logger;
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectMember> ProjectMembers { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }

        public LubyClockerContext(DbContextOptions<LubyClockerContext> options, IConfiguration config, ILogger<LubyClockerContext> logger) : base(options)
        {
            Logger = logger;
            Configuration = config;
            
            Database.Migrate();
        }

        public bool HasChanges => ChangeTracker.HasChanges();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Parent On Model Creating
            base.OnModelCreating(builder);
            
            // Configure Models
            ConfigureModels(builder);
            
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.GetTableName().Singularize());
            }
        }

        private void ConfigureModels(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DeveloperMap).Assembly);
        }
    }
}