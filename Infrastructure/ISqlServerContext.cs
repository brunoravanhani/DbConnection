using System;
using System.Data.SqlClient;

namespace DbConnection.Infrastructure
{
    public interface ISqlServerContext
    {
        SqlConnection GetConnection();
    }
}