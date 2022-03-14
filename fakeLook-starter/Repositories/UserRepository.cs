using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly private DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            //throw new NotImplementedException();
            var res = _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<User> Edit(User item)
        {
            var user = _context.Users.FirstOrDefault(u => item.Id == u.Id);
            if (user == null) return null;
            _context.Entry<User>(user).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            return user;
        }

        public ICollection<User> GetAll()
        {
            //throw new NotImplementedException();
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(p => p.Id == id);
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            //throw new NotImplementedException();
            return _context.Users.Where(predicate).ToList();

        }
    }
}
