using System;
using System.Data.SqlClient;

namespace DbConnection.Infrastructure
{
    public class SqlServerContext : ISqlServerContext
    {

        private String ConnectionString;

        public SqlServerContext(String connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}