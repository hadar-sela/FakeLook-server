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
            //item.Password = item.Password.GetHashCode().ToString();
            var res = _context.Users.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<User> Edit(User item)
        {
            var user = _context.Users.FirstOrDefault(u => item.Id == u.Id);
            if (user == null) return null;
            _context.Entry<User>(user).CurrentValues.SetValues(item);
           // _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;

            //await _context.SaveChangesAsync();
            //return user;
            //var res = _context.Users.Update(item);
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.SingleOrDefault(p => p.Id == id);
        }
    
        public User GetByUserBirth(User user)
        {
            if (user != null)
            {
                return _context.Users.Where(u => u.UserName == user.UserName && u.BirthDate == user.BirthDate).SingleOrDefault();
            }
            return null;
        }
        public User GetByUser(User user)
        {
            if (user != null)
            {
                return _context.Users.Where(u => u.UserName == user.UserName && u.Password == user.Password).SingleOrDefault();
            }
            return null;
        }

        public ICollection<User> GetByPredicate(Func<User, bool> predicate)
        {
            return _context.Users.Where(predicate).ToList();
        }

        public async Task<User> Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
