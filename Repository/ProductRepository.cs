using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public bool Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Product Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> items = new List<Product>();

            using(SqlConnection connection = Context.GetConnection() as SqlConnection) 
            {
                connection.Open();
                
                SqlCommand command = new SqlCommand("SELECT ID_PRODUCT,DESCRIPTION,PRICE FROM PRODUCT",connection);
                
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
            throw new NotImplementedException();
        }
    }
}