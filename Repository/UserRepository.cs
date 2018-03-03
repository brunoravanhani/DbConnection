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
            bool result = false;

            using (MySqlConnection connection = Context.GetConnection() as MySqlConnection)
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand($"INSERT INTO USER (NAME) VALUES('{entity.Name}')", connection);

                var queryResult = command.ExecuteNonQuery();
                
                result = queryResult != -1;
            }

            return result;
        }

        public bool Update(User entity)
        {
            bool result = false;

            using (MySqlConnection connection = Context.GetConnection() as MySqlConnection)
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand($"UPDATE USER SET NAME = '{entity.Name}' WHERE ID_USER = {entity.Id}", connection);

                var queryResult = command.ExecuteNonQuery();
                
                result = queryResult != -1;
            }

            return result;
        }

        public bool Delete(long id)
        {
            bool result = false;

            using (MySqlConnection connection = Context.GetConnection() as MySqlConnection)
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand($"DELETE FROM USER WHERE ID_USER = {id}", connection);

                var queryResult = command.ExecuteNonQuery();
                
                result = queryResult != -1;
            }

            return result;
        }

        public User Get(long id)
        {
            User user = null;
            using (MySqlConnection connection = Context.GetConnection() as MySqlConnection) 
            {
                connection.Open();

                DbCommand command = new MySqlCommand($"SELECT * FROM USER WHERE ID_USER = {id}", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        user = new User {
                            Id = Int64.Parse(reader["ID_USER"].ToString()),
                            Name = reader["NAME"].ToString()
                        };
                    }
                }

                connection.Close();
                return user;
            }
        }

        public IEnumerable<User> GetAll () {

            List<User> items = new List<User>();
            using (MySqlConnection connection = Context.GetConnection() as MySqlConnection) 
            {
                connection.Open();

                DbCommand command = new MySqlCommand("SELECT * FROM USER", connection);
                
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
        
    }
}