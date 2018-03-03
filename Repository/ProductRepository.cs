using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using DbConnection.Infrastructure;
using DbConnection.Model;

namespace DbConnection.Repository
{
    public class ProductRepository : IRepository<Product, Int64>
    {

        public ProductRepository(SqlServerContext context)
        {
            this.Context = context;
        }

        private IContext Context { get; set; }

        public bool Add(Product entity)
        {
            bool result = false;
            using(IDbConnection connection = Context.GetConnection()) 
            {
                connection.Open();
                
                IDbCommand command = Context.GetCommand(
                    $"INSERT INTO PRODUCT (DESCRIPTION, PRICE) VALUES ('{entity.Description}', {entity.Price})", connection);
                
                var queryResult = command.ExecuteNonQuery();

                result = queryResult > 0;
            }
            return result;
        }

        public bool Delete(long id)
        {
            bool result = false;
            using(IDbConnection connection = Context.GetConnection()) 
            {
                connection.Open();
                
                IDbCommand command = Context.GetCommand(
                    $"DELETE FROM PRODUCT WHERE ID_PRODUCT = {id}", connection);
                
                var queryResult = command.ExecuteNonQuery();

                result = queryResult > 0;
            }
            return result;
        }

        public Product Get(long id)
        {
            Product product = null;

            using(IDbConnection connection = Context.GetConnection()) 
            {
                connection.Open();
                
                IDbCommand command = Context.GetCommand($"SELECT ID_PRODUCT,DESCRIPTION,PRICE FROM PRODUCT WHERE ID_PRODUCT = {id}", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        product = new Product
                        {
                            Id = Int64.Parse(reader["ID_PRODUCT"].ToString()),
                            Description = reader["DESCRIPTION"].ToString(),
                            Price = Double.Parse(reader["PRICE"].ToString())
                        };
                    }
                }
            }
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> items = new List<Product>();

            using(IDbConnection connection = Context.GetConnection()) 
            {
                connection.Open();
                
                IDbCommand command = Context.GetCommand("SELECT ID_PRODUCT,DESCRIPTION,PRICE FROM PRODUCT", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        items.Add(new Product
                        {
                            Id = Int64.Parse(reader["ID_PRODUCT"].ToString()),
                            Description = reader["DESCRIPTION"].ToString(),
                            Price = Double.Parse(reader["PRICE"].ToString())
                        });
                    }
                }
            }

            return items;
        }

        public bool Update(Product entity)
        {
            bool result = false;
            using(IDbConnection connection = Context.GetConnection()) 
            {
                connection.Open();
                
                IDbCommand command = Context.GetCommand(
                    $@"UPDATE PRODUCT SET DESCRIPTION = '{entity.Description}', PRICE = {entity} 
                        WHERE ID_PRODUCT = {entity.Id}", connection);
                
                var queryResult = command.ExecuteNonQuery();

                result = queryResult != -1;
            }
            return result;
        }
    }
}