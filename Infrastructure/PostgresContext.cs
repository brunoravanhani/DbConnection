using System;
using System.Data;
using Npgsql;

namespace DbConnection.Infrastructure 
{
    public class PostgresContext : IPostgresContext
    {
        private string ConnectionString { get; set; }

        public PostgresContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}