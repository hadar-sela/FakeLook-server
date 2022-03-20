using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaggedPostController : ControllerBase
    {
        // GET: api/<UserTaggedPostController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserTaggedPostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserTaggedPostController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserTaggedPostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserTaggedPostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
