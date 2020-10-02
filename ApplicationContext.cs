using LancamentoHorasAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancamentoHorasAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> opcoes) : base(opcoes)
        {
        }
    }
}
