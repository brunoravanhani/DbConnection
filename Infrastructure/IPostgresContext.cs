using System;
using Npgsql;

namespace DbConnection.Infrastructure
{
    public interface IPostgresContext
    {
        NpgsqlConnection GetConnection();
    }
}