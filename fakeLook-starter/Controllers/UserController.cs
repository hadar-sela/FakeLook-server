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
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repository;

        public UserController(DataContext context)
        {
            _repository = new UserRepository(context);
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {

            return _repository.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {

            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("GetByUsername/{username}")]
        public User GetByUsername(string username)
        {
            return _repository.GetByUsername(username);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _ = _repository.Add(value);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            _ = _repository.Edit(value);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
