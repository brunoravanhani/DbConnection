using System;
using MySql.Data.MySqlClient;

namespace DbConnection.Infrastructure
{
    public interface IMySqlContext
    {
        MySqlConnection GetConnection ();
    }
}