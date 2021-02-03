using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LH001.Domain.Entidades;

namespace LH001.Contexto
{
    public class BdContext : DbContext
    {
        public BdContext(DbContextOptions<BdContext> options)
            : base(options)
        { }

        public DbSet<Tb_Desenvolvedor> Tb_Desenvolvedores { get; set; }
        public DbSet<Tb_Projeto> Tb_Projetos { get; set; }

        public DbSet<Tb_Desenvolvedor_Projeto> Tb_Desenvolvedores_Projetos { get; set; }

        public DbSet<Tb_LancamentoHoras> Tb_LancamentosHoras { get; set; }
    }
}

