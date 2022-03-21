using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Filters;
using fakeLook_starter.Interfaces;
using fakeLook_starter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace fakeLook_starter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private ITokenService _tokenService { get; }

        public UserController(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
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
        [TypeFilter(typeof(GetUserActionFilter))]
        public User Get(int id)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            return _repository.GetById(user.Id);
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user == null) 
                return Problem("null");
            var dbUser = _repository.GetByUser(user);
            if (dbUser == null) return Problem("Incorrect");
            var token = _tokenService.CreateToken(dbUser);
            return Ok(new { token, dbUser.Id, dbUser.UserName });
        }

        // POST api/<UsersController>
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            if (value == null)
                return Problem("null");
            try
            {
                var dbUser =  (_repository.Add(value)).Result;
                var token = _tokenService.CreateToken(dbUser);
                return Ok(new { token, dbUser.Id, dbUser.UserName });
            }
            catch
            {
                return Problem("Username already exist");
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        [TypeFilter(typeof(GetUserActionFilter))]
        public void Put([FromBody] User value)
        {
            Request.RouteValues.TryGetValue("user", out var obj);
            var user = obj as User;
            value.Id = user.Id;
            if (value == null)
            {
                return;
            }
            // If the client tries to change the username to used username it is
            // not possible to change user's attributes any more
            _ = _repository.Edit(value);
        }


        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
