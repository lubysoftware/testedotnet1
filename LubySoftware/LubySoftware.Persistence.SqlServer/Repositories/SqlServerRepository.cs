﻿using LubySoftware.Persistence.Repositories;
using System.Data;
using System.Data.SqlClient;

namespace LubySoftware.Persistence.SqlServer.Repositories
{
    public class SqlServerRepository : DapperRepository
    {
        readonly string ConnectionString;

        public SqlServerRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public override IDbConnection Connection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
