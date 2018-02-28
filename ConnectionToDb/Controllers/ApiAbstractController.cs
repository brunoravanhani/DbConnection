using ConnectionToDb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConnectionToDb.Controllers
{
    public abstract class ApiAbstractController<TEntity, TId> : ApiController
    {
        protected IRepository<TEntity, TId> Repository;

        public virtual IEnumerable<TEntity> Get()
        {
            return Repository.GetAll();
        }

        public virtual TEntity Get(TId id)
        {
            return Repository.Get(id);
        }

        public virtual bool Post(TEntity entity)
        {
            return Repository.Add(entity);
        }

        public virtual bool Put(TEntity entity)
        {
            return Repository.Update(entity);
        }
        
        public virtual bool Delete(TId id)
        {
            return Repository.Delete(id);
        }
    }
}
