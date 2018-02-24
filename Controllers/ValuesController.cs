using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection.Infrastructure;
using DbConnection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DbConnection.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        private readonly ValuesMySqlRepository MySqlRepository;
        private readonly ValuesPostgresRepository PostgresRepository;
        private readonly MySqlContext MySqlContext;
        private readonly PostgresContext PostgresContext;

        public ValuesController(IMySqlContext mySqlcontext, IPostgresContext postgresContext) 
        {
            MySqlContext = mySqlcontext as MySqlContext;
            PostgresContext = postgresContext as PostgresContext;
            MySqlRepository = new ValuesMySqlRepository(MySqlContext);
            PostgresRepository = new ValuesPostgresRepository(PostgresContext);
        }

        // GET api/values
        [HttpGet]
        [Route("MySql")]
        public IEnumerable<string> MySql()
        {
            return MySqlRepository.Get();
        }

        [HttpGet]
        [Route("Postgresql")]
        public IEnumerable<string> PostgreSql()
        {
            return PostgresRepository.Get();
        }

    }
}
