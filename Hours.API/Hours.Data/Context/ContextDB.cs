using Hours.Data.Mapping;
using Hours.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hours.Data.Context
{
    public class ContextDB : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<HoursEntity> Hours { get; set; }

        public ContextDB (DbContextOptions<ContextDB> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<HoursEntity>(new HoursMap().Configure);
        }

    }
}
