using System;
using System.Collections.Generic;
using DbConnection.Infrastructure;
using MySql.Data.MySqlClient;

namespace DbConnection.Repository
{
    public class ValuesMySqlRepository
    {

        private readonly MySqlContext Context;

        public ValuesMySqlRepository (MySqlContext context)
        {
            this.Context = context;
        }
        
        public IEnumerable<string> Get () {

            List<string> items = new List<string>();
            using (MySqlConnection connection = Context.GetConnection()) 
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM user", connection);

                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        items.Add(reader["Name"].ToString());
                    }
                }
                return items;
            }
        }
    }
}