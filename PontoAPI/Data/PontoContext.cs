using PontoAPI.Data.Mappings;
using PontoAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PontoAPI.Data
{
    public class PontoContext : DbContext
    {
        private static IConfigurationRoot Configuration => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        public DbSet<Desenvolvedor> DesenvolvedorSet { get; set; }

        public DbSet<Projeto> ProjetoSet { get; set; }

        public PontoContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DataBase"));
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.EnableDetailedErrors(true);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DesenvolvedorMapping());
            modelBuilder.ApplyConfiguration(new ProjetoMapping());
        }
    }
}