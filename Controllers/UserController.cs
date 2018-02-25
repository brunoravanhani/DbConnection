using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection.Infrastructure;
using DbConnection.Model;
using DbConnection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DbConnection.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ApiController<User, Int64>
    {
        
        private readonly MySqlContext MySqlContext;

        public UserController(IMySqlContext mySqlcontext) 
        {
            MySqlContext = mySqlcontext as MySqlContext;
            Repository = new UserRepository(MySqlContext);
        }

    }
}
