using ApiLuby.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Data;

namespace ApiLuby.Configurations
{
    public class DbFactoryBcContext : IDesignTimeDbContextFactory<BankOfHoursDbContext>
    {
        public BankOfHoursDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BankOfHoursDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=LUBY;user=sa;password=1234567");
            BankOfHoursDbContext contexto = new BankOfHoursDbContext(optionsBuilder.Options);
            return contexto;
        }

        public static IDbConnection FactoryNewConnection(bool adocao = false)
        {
            IDbConnection conn = null;
            conn = new SqlConnection("Server=localhost;Database=LUBY;user=sa;password=1234567");
            conn.Open();
            return conn;
        }
    }
}
