using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteApi.Models;

// Context vai encapsular todas as propriedades
namespace TesteApi.Data
{
    public class TesteApiContext : DbContext
    {
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<HoraTrabalhada> HorasTrabalhadas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        public TesteApiContext(DbContextOptions<TesteApiContext> options) : base(options)
            {
            }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoraTrabalhada>(e => 
            {
                e.HasKey(p => new { p.ProjetoId, p.DesenvolvedorId });
            });
        }

    }
}