using System;
using DbConnection.Infrastructure;
using DbConnection.Model;
using DbConnection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DbConnection.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ApiController<Product, Int64>
    {
        
        public ProductController(ISqlServerContext context)
        {
            this.Context = context as SqlServerContext  ;
            Repository = new ProductRepository(Context);
        }

        private readonly SqlServerContext Context;

    }
}