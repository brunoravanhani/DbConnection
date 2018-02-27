using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using DbConnection.Infrastructure;
using DbConnection.Model;
using MySql.Data.MySqlClient;

namespace DbConnection.Repository
{
    public class UserRepository : IRepository<User, long>
    {

        public UserRepository(MySqlContext context)
        {
            this.Context = context;
        }

        private IContext Context { get; set; }

        public bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll () {

            List<User> items = new List<User>();
            using (MySqlConnection connection = Context.GetConnection() as MySqlConnection) 
            {
                connection.Open();

                DbCommand command = new MySqlCommand("SELECT * FROM user", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        items.Add(new User {
                            Id = Int64.Parse(reader["ID_USER"].ToString()),
                            Name = reader["NAME"].ToString()
                        });
                    }
                }

                connection.Close();
                return items;
            }
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}