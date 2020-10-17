using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteDotNet.ControleHoras.Dominio.Entidades;

namespace Infra.Dados.Base
{
    public class DbContexto : DbContext
    {
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<RegistroHora> RegistroHoras { get; set; }

        public DbContexto(DbContextOptions<DbContexto> options) : base(options) 
        { 
        }
    }
}
