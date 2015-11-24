using AspNetNg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace AspNetNg.api
{
    public class DogsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Dog()
        {
            return Ok();
        }
    }
}