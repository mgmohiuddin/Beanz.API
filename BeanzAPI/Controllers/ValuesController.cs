using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Beanz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet]
        //public ActionResult<string> TestService()
        //{
        //    try
        //    {
        //        string result = "{This Service is working}";
        //        return result;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return ex.Message.ToString();
        //    }
        //}

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value t";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
