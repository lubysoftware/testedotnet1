using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace lancamentoHoras.Database
{
    public static class DBConnection
    {
        private static readonly string connString = "server=localhost;user id=root;password=password123;port=3310;database=lubydatabase;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connString);
        }
    }
}
