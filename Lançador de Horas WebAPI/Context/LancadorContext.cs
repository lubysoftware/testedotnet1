using Lançador_de_Horas_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Lançador_de_Horas_WebAPI.Context
{
    public class LancadorContext : IdentityDbContext<ApplicationUser>
    {
        public LancadorContext(DbContextOptions<LancadorContext> options) : base(options)
        {
        }

        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<RegistroDeHoras> RegistrosDeHoras { get; set; }
    }
}