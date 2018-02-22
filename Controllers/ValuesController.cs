using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbConnection.Infraestructure;
using DbConnection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DbConnection.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        
        private readonly ValuesMySqlRepository repository;

        public ValuesController() 
        {
            MySqlContext context = new MySqlContext("server=localhost;port=3306;database=db_test;user=root;password=ravanhani");
            repository = new ValuesMySqlRepository(context);
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return repository.Get();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
