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

        public ProductRepository(IContext context)
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
                    $"INSERT INTO PRODUTO (DESCRICAO, PRICE) VALUES ('{entity.Description}', {entity.Price})", connection);
                
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
                    $"DELETE FROM PRODUTO WHERE ID_PRODUTO = {id}", connection);
                
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
                
                IDbCommand command = Context.GetCommand($"SELECT ID_PRODUTO,DESCRICAO,PRICE FROM PRODUTO WHERE ID_PRODUTO = {id}", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        product = new Product
                        {
                            Id = Int64.Parse(reader["ID_PRODUTO"].ToString()),
                            Description = reader["DESCRICAO"].ToString(),
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
                
                IDbCommand command = Context.GetCommand("SELECT ID_PRODUTO,DESCRICAO,PRICE FROM PRODUTO", connection);
                
                using(var reader = command.ExecuteReader()) 
                {
                    while(reader.Read())
                    {
                        items.Add(new Product
                        {
                            Id = Int64.Parse(reader["ID_PRODUTO"].ToString()),
                            Description = reader["DESCRICAO"].ToString(),
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
                    $@"UPDATE PRODUTO SET DESCRICAO = '{entity.Description}', PRICE = {entity} 
                        WHERE ID_PRODUTO = {entity.Id}", connection);
                
                var queryResult = command.ExecuteNonQuery();

                result = queryResult != -1;
            }
            return result;
        }
    }
}