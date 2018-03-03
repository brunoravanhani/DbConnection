using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace DbConnection.Infrastructure
{
    public class MySqlContext : IMySqlContext
    {
        private string ConnectionString { get; set; }

        public MySqlContext(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IDbConnection GetConnection () 
        {
            return new MySqlConnection(ConnectionString);
        }

        public IDbCommand GetCommand(string sql, IDbConnection connection)
        {
            return new MySqlCommand(sql, connection as MySqlConnection);
        }
    }
}