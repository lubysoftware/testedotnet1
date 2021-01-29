using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TesteApi.Models;

// Context vai encapsular todas as propriedades
namespace TesteApi.Data
{
    public class DesenvolvedorContext : DbContext
    {
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<HoraTrabalhada> HorasTrabalhadas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=TesteApiBd;Data Source=DESKTOP-H6G5SVI\\SQLEXPRESS");
        }

    }
}