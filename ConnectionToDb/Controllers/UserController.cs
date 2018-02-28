using ConnectionToDb.Models;
using ConnectionToDb.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConnectionToDb.Controllers
{
    public class UserController : ApiAbstractController<User, Int64>
    {
        
        public UserController()
        {
            Repository = new UserRepository();
        }
    }
}
