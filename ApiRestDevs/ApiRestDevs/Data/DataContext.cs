using ApiRestDevs.Models;
using Microsoft.EntityFrameworkCore;


namespace ApiRestDevs.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
              : base(options)
        {
        }

        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<LancamentoDeHora> LancamentoDeHoras { get; set; }
        public DbSet<User> Users { get; set; }

        // Mapeando banco com Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LancamentoDeHora>()
                .HasOne(s => s.Desenvolvedor)
                .WithMany(g => g.LancamentoDeHoras)
                .HasForeignKey(s => s.DesenvolvedorId);

            modelBuilder.Entity<LancamentoDeHora>()
                .HasOne(s => s.ProjetoTrabalhado)
                .WithMany(g => g.LancamentoDeHoras)
                .HasForeignKey(s => s.ProjetoTrabalhadoId);

            modelBuilder.Entity<LancamentoDeHora>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<LancamentoDeHora>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Projeto>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Projeto>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Desenvolvedor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Desenvolvedor>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<User>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<User>()
                .Property(x => x.Role).HasColumnType("varchar(20)");

            modelBuilder.Entity<User>()
                .Property(x => x.Role).HasDefaultValue("all");

            base.OnModelCreating(modelBuilder);
        }

    }

}
