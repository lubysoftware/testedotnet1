using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace API.Extensions
{
    public class SqlServerHealthCheck : IHealthCheck
    {
        private readonly string _conexao;
        public SqlServerHealthCheck(string conexao)
        {
            _conexao = conexao;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                using (var conexao = new SqlConnection(_conexao))
                {
                    await conexao.OpenAsync(cancellationToken);

                    var comando = conexao.CreateCommand();

                    comando.CommandText = "select count(id) from produtos";

                    return Convert.ToInt32(await comando.ExecuteScalarAsync(cancellationToken)) > 0 ? HealthCheckResult.Healthy() : HealthCheckResult.Unhealthy();
                }
            }
            catch (Exception)
            {
                return HealthCheckResult.Unhealthy();
            }
        }
    }
}
