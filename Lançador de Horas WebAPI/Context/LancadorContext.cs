using Lançador_de_Horas_WebAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lançador_de_Horas_WebAPI.Context
{
    /// <summary>
    /// Contexto de dados
    /// </summary>
    public class LancadorContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Contrutor
        /// </summary>
        /// <param name="options">Contexto options</param>
        public LancadorContext(DbContextOptions<LancadorContext> options) : base(options)
        {
        }

        /// Tabela Desenvolvedor
        public DbSet<Desenvolvedor> Desenvolvedores { get; set; }

        /// Tabela Projeto
        public DbSet<Projeto> Projetos { get; set; }

        /// Tabela Registro de Horas
        public DbSet<RegistroDeHoras> RegistrosDeHoras { get; set; }
    }
}