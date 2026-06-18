using Hours.Domain.Entities;
using Hours.Infra.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Hours.Infra.Context
{
    public class ContextDB : DbContext
    {
        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<HoursEntity> Hours { get; set; }

        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsersEntity>(new UserMap().Configure);
            modelBuilder.Entity<HoursEntity>(new HoursMap().Configure);
        }
    }
}