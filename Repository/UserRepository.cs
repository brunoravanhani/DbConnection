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

        public UserRepository(IContext context)
        {
            this.Context = context;
        }

        private IContext Context { get; set; }

        public bool Add(User entity)
        {
            bool result = false;

            using (IDbConnection connection = Context.GetConnection())
            {
                connection.Open();

                IDbCommand command = Context.GetCommand($"INSERT INTO USUARIO (NOME) VALUES('{entity.Name}')", connection);

                var queryResult = command.ExecuteNonQuery();
                
                result = queryResult > 0;
            }

            return result;
        }

        public bool Update(User entity)
        {
            bool result = false;

            using (IDbConnection connection = Context.GetConnection())
            {
                connection.Open();

                IDbCommand command = Context.GetCommand($"UPDATE USUARIO SET NOME = '{entity.Name}' WHERE ID_USUARIO = {entity.Id}", connection);

                var queryResult = command.ExecuteNonQuery();
                
                result = queryResult > 0;
            }

            return result;
        }

        public bool Delete(long id)
        {
            bool result = false;

            using (IDbConnection connection = Context.GetConnection())
            {
                connection.Open();

                IDbCommand command = Context.GetCommand($"DELETE FROM USUARIO WHERE ID_USUARIO = {id}", connection);

                var queryResult = command.ExecuteNonQuery();
                
                result = queryResult > 0;
            }

            return result;
        }

        public User Get(long id)
        {
            User user = null;
            using (IDbConnection connection = Context.GetConnection()) 
            {
                connection.Open();

                IDbCommand command = Context.GetCommand($"SELECT * FROM USUARIO WHERE ID_USUARIO = {id}", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        user = new User {
                            Id = Int64.Parse(reader["ID_USUARIO"].ToString()),
                            Name = reader["NOME"].ToString()
                        };
                    }
                }

                connection.Close();
                return user;
            }
        }

        public IEnumerable<User> GetAll () {

            List<User> items = new List<User>();
            using (IDbConnection connection = Context.GetConnection()) 
            {
                connection.Open();

                IDbCommand command = Context.GetCommand("SELECT * FROM USUARIO", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        items.Add(new User {
                            Id = Int64.Parse(reader["ID_USUARIO"].ToString()),
                            Name = reader["NOME"].ToString()
                        });
                    }
                }

                connection.Close();
                return items;
            }
        }
        
    }
}