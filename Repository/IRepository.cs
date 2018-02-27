using System;
using System.Collections.Generic;
using DbConnection.Infrastructure;

namespace DbConnection.Repository
{
    public interface IRepository<TEntity, TId>
    {

        TEntity Get(TId id);
        
        IEnumerable<TEntity> GetAll();

        bool Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TId id);

    }
}