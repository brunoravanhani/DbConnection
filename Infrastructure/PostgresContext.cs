using System;
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

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(ConnectionString);
        }
    }
}