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

        public UserController(IMySqlContext context) 
        {
            this.Context = context as MySqlContext;
            Repository = new UserRepository(Context);
        }

        private readonly IContext Context;

    }
}
