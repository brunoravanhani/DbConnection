using System;
using System.Data;

namespace DbConnection.Infrastructure
{
    public interface IContext
    {
        IDbConnection GetConnection();

        IDbCommand GetCommand(String sql, IDbConnection connection);
    }
}