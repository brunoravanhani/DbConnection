using ConnectionToDb.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ConnectionToDb.Repository
{
    public class UserRepository : IRepository<User, Int64>
    {
        private String ConnectionString { get; set; }

        public UserRepository()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["MySqlServer"].ConnectionString;
        }

        public User Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> items = new List<User>();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM user", connection);

                using (var reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        items.Add(new User
                        {
                            Id = Int64.Parse(reader["ID_USER"].ToString()),
                            Name = reader["NAME"].ToString()
                        });
                    }

                }
                connection.Close();
            }

            return items;
        }

        public bool Add(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(User entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}