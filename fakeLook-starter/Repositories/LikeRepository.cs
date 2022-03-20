using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        readonly private DataContext _context;
        private readonly IDtoConverter _converter;

        public LikeRepository(DataContext context, IDtoConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<Like> Add(Like item)
        {
            var res = _context.Likes.Add(item);
            await _context.SaveChangesAsync();
            return _converter.DtoLike(res.Entity);
        }

        public async Task<Like> Delete(int id)
        {
            var like = _context.Likes.SingleOrDefault(l => l.Id == id);
            if (like == null)
                return null;
            _context.Likes.Remove(like);
            await _context.SaveChangesAsync();
            return _converter.DtoLike(like);
        }

        public Task<Like> Edit(Like item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Like> GetAll()
        {
            return _context.Likes.Select(l => _converter.DtoLike(l)).ToList();
        }

        public Like GetById(int id)
        {
            return _converter.DtoLike(_context.Likes.SingleOrDefault(l => l.Id == id));
        }

        public ICollection<Like> GetByPredicate(Func<Like, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
