using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ConnectionToDb.Infrastructure
{
    public class MySqlContext : IMySqlContext
    {

        public MySqlContext(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public String ConnectionString { get; set; }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}