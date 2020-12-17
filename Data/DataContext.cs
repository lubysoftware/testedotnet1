using Microsoft.EntityFrameworkCore;
using testedotnet1.Models;

namespace testedotnet1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> optins) : base(optins)
        {}

        public DbSet<Desenvolvedor> Desenvolvedores {get; set;}
        public DbSet<Avaliacao> Avaliacoes {get; set;}
        public DbSet<Projeto> Projetos {get; set;}
    }
}