using Microsoft.EntityFrameworkCore;
using testedotnet1.Entities;

namespace testedotnet1.Data
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options) { }

        public DbSet<User> UserDbContext { get; set; }
        public DbSet<Project> ProjectDbContext { get; set; }
        public DbSet<HoursAtWork> HoursDbContext { get; set; }

    }
}