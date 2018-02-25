using System;
using System.Collections.Generic;
using DbConnection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DbConnection.Controllers
{
    public class ApiController<TEntity, TId>: Controller
    {
        protected IRepository<TEntity, TId> Repository;

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return Repository.GetAll();
        }

        [HttpGet("{id}")]
        public TEntity Get(TId id)
        {
            return Repository.Get(id);
        }

        [HttpPost]
        public bool Post(TEntity entity)
        {
            return Repository.Add(entity);
        }

        [HttpPut]
        public bool Put(TEntity entity)
        {
            return Repository.Update(entity);
        }

        [HttpDelete("{id}")]
        public bool Delete(TId id)
        {
            return Repository.Delete(id);
        }
    }
}