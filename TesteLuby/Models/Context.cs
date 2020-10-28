using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteLuby.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desenvolvedor>().ToTable("Desenvolvedor");
            modelBuilder.Entity<Projeto>().ToTable("Projeto");
            modelBuilder.Entity<LançamentoHora>().ToTable("Lancamento_Hora");
        }

        public DbSet<Desenvolvedor> Desenvolvedor { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<LançamentoHora> LançamentoHora { get; set; }
    }
}
