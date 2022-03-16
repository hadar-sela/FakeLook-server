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
            item.Password = item.Password.GetHashCode().ToString();
            var res = _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }


        public async Task<User> Edit(User item)
        {
            var user = _context.Users.FirstOrDefault(u => item.Id == u.Id);
            if (user == null) return null;
            //await _context.SaveChangesAsync();
            //return user;
            //var res = _context.Users.Update(item);
            _context.Entry<User>(user).CurrentValues.SetValues(item);
            
            await _context.SaveChangesAsync();
            return user;
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(p => p.Id == id);
        }
        public User GetByUser(User user)
        {
            //hash
            if (user != null)
            {
                return _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).SingleOrDefault();
            }
            return null;
            //return _context.Users.SingleOrDefault(p => p.UserName == user.UserName && p.Password==user.Password );
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            return _context.Users.Where(predicate).ToList();

        }

    }
}
