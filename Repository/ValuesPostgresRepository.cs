using System;
using System.Collections.Generic;
using DbConnection.Infrastructure;
using Npgsql;

namespace DbConnection.Repository
{
    public class ValuesPostgresRepository
    {

        private readonly PostgresContext Context;

        public ValuesPostgresRepository(PostgresContext context)
        {
            this.Context = context;
        }

        public IEnumerable<string> Get () {
        
            List<string> items = new List<string>();

            using(NpgsqlConnection connection = Context.GetConnection()) 
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("select * from users", connection);

                using (var reader = command.ExecuteReader()) 
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