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
        private readonly ValuesSqlServerRepository SqlServerRepository;
        private readonly MySqlContext MySqlContext;
        private readonly PostgresContext PostgresContext;
        private readonly SqlServerContext SqlServerContext;

        public ValuesController(IMySqlContext mySqlcontext, IPostgresContext postgresContext, 
                                ISqlServerContext sqlServerContext) 
        {
            MySqlContext = mySqlcontext as MySqlContext;
            PostgresContext = postgresContext as PostgresContext;
            SqlServerContext = sqlServerContext as SqlServerContext;
            MySqlRepository = new ValuesMySqlRepository(MySqlContext);
            PostgresRepository = new ValuesPostgresRepository(PostgresContext);
            SqlServerRepository = new ValuesSqlServerRepository(SqlServerContext);
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

        [HttpGet]
        [Route("SqlServer")]
        public IEnumerable<string> SqlServer()
        {
            return SqlServerRepository.Get();
        }


    }
}
