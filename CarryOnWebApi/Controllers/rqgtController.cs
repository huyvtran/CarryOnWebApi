using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarryOnWebApi.Controllers
{
    public class rqgtController : ApiController
    {
        // GET: api/rqgt
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/rqgt/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/rqgt
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/rqgt/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/rqgt/5
        public void Delete(int id)
        {
        }
    }
}
