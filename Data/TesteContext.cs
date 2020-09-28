using Microsoft.EntityFrameworkCore;
using testedotnet1.Entities;

namespace testedotnet1.Data
{
    public class TesteContext : DbContext
    {
        public TesteContext(DbContextOptions<TesteContext> options) : base(options) { }

        public DbSet<User> UserItems { get; set; }
        public DbSet<Project> ProjectItems { get; set; }
        public DbSet<HoursAtWork> HoursItems { get; set; }

    }
}