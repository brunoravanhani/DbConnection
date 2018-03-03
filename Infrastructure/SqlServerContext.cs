using System;
using System.Data;
using System.Data.Common;
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

        public IDbCommand GetCommand(String sql, IDbConnection connection)
        {
            return new SqlCommand(sql, connection as SqlConnection);
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}