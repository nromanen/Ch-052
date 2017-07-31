using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;
using Advertisements.Web.Models;
using Newtonsoft.Json;

namespace Advertisements.Web.Controllers
{
    //[Authorize]

    //[DisableCors]
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public JsonResult<List<TempModel>> Get()
        {
            List<TempModel> listForTesting = new List<TempModel>();
            listForTesting.Add(new TempModel() {id = 1, name = "Test1"});
            listForTesting.Add(new TempModel() {id = 2, name = "Test2"});
            return Json(listForTesting);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
