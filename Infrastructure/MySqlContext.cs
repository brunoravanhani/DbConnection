using System;
using MySql.Data.MySqlClient;

namespace DbConnection.Infrastructure
{
    public class MySqlContext : IMySqlContext
    {
        
        public string ConnectionString { get; set; }

        public MySqlContext(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public MySqlConnection GetConnection () 
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}