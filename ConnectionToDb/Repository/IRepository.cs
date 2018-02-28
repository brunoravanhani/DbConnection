using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionToDb.Repository
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
