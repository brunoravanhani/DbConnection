using System;
using MySql.Data.MySqlClient;

namespace DbConnection.Infraestructure
{
    public class MySqlContext
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