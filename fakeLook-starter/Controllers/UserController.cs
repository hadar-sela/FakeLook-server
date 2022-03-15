using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
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
        private ITokenService _tokenService { get; }

        public UserController(DataContext context, ITokenService tokenService)
        {
            _repository = new UserRepository(context);
            _tokenService = tokenService;
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

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            var dbUser = _repository.GetByUser(user);
            if (dbUser == null) return Problem("user not in system");
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            var dbUser = _repository.Register(value);
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token });
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
