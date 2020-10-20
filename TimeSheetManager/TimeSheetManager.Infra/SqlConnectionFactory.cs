using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TimeSheetManager.App.Handlers.Contracts;

namespace TimeSheetManager.Infra
{
    public class SqlConnectionFactory : ISqlConnection
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetOpenConnection()
        {
            if (this._connection == null || this._connection.State != ConnectionState.Open)
            {
                this._connection = new SqlConnection(_connectionString);
                this._connection.Open();
            }
            return this._connection;
        }
    }
}
