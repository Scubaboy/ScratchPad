using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace robswebapi.Controllers
{
    public class RobsController : ApiController
    {
        [Route("api/robs/{id}")]
        public string GetIds(int id)
        {
            return "the value " + id.ToString();
        }

        [Route("api/robs/up")]
        public HttpResponseMessage PostIds([FromBody]Product data)
        {
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}