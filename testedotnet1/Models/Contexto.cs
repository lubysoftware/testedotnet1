using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testedotnet1.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            :base(options)
        {

        }

        public DbSet<Desenvolvedor> tbl_Desenvolvedor { get; set; }
        public DbSet<Projeto> tbl_Projeto { get; set; }
        public DbSet<Relogio_Ponto> tbl_RelogioPonto { get; set; }
    }
   
}
