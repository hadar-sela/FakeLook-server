using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {

        private readonly ICommentRepository _repository;

        public CommentController(ICommentRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<CommentController>
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<Comment> Post([FromBody] Comment value)
        {
            return await _repository.Add(value);
        }

        // PUT api/<CommentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
