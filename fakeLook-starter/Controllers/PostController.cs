using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostRepository _repository;

        public PostController(DataContext context)
        {
            _repository = new PostRepository(context);
        }
        // GET: api/<PostsController>
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PostsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
