using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DbConnection.Infrastructure;


namespace DbConnection.Repository
{
    public class ValuesSqlServerRepository
    {

        private readonly SqlServerContext Context;

        public ValuesSqlServerRepository(SqlServerContext context)
        {
            this.Context = context;
        }

        public IEnumerable<string> Get () {
        
            List<string> items = new List<string>();

            using(SqlConnection connection = Context.GetConnection()) 
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT [ID_USER],[NAME] FROM [master].[dbo].[USERS]",connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        items.Add(reader["name"].ToString());
                    }
                }
            }

            return items;

        }
    }
}