using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Context
{
    /// <summary>
    /// Classe que representa o contexto da aplicação
    /// </summary>
    /// <remarks>
    /// Autor   : Luiz Fernando
    /// Data    : 21/09/2020
    /// </remarks>
    public class MyDbContext : DbContext
    {
        #region Constructor
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        #endregion Constructor

        #region Properties
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<LaunchTime> LaunchTimes { get; set; }
        #endregion Properties

        #region Methods Overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Caso possua data de cadastro nos objetos atualiza automatico
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        #endregion Methods Overrides
    }
}
