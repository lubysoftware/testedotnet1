namespace Luby.Data.Context
{
    using Luby.Core.Model;
    using Microsoft.EntityFrameworkCore;
    public class LubyContext : DbContext
    {
        public LubyContext(DbContextOptions<LubyContext> opt) : base(opt) { }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores{ get; set; }
        public DbSet<ProjetoDesenvolvedores> ProjetoDesenvolvedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LubyContext).Assembly);
        }
    }
}