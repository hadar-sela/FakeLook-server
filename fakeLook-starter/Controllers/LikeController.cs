using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeRepository _repository;
        public LikeController(ILikeRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<LikeController>
        [HttpGet]
        public IEnumerable<Like> Get()
        {
            return _repository.GetAll();
        }

        // GET api/<LikeController>/5
        [HttpGet("{id}")]
        public Like Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST api/<LikeController>
        [HttpPost]
        public void Post([FromBody] Like value)
        {
            _ = _repository.Add(value);
        }

        // PUT api/<LikeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Like value)
        {
            _ = _repository.Edit(value);
        }

        // DELETE api/<LikeController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
