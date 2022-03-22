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
            if (LikeExist(item))
            {
                var like = _context.Likes.SingleOrDefault(l => l.UserId == item.UserId && l.PostId == item.PostId);
                if (like.IsActive)
                {
                    return await Deletelike(like);
                }
                else
                {
                    like.IsActive = true;
                    _context.SaveChanges();
                    return like;
                }
            }
            else
            {
                item.IsActive = true;
                var addedlike = _context.Add(item);
                _context.SaveChanges();
                return addedlike.Entity;
            }
        }

        private bool LikeExist(Like item)
        {
            var like = _context.Likes.SingleOrDefault(l => l.UserId == item.UserId && l.PostId == item.PostId);
            return like != null;
        }

        public async Task<Like> Deletelike(Like like)
        {
            var likeDb = like;
            likeDb.IsActive = false;
            _context.Entry<Like>(like).CurrentValues.SetValues(likeDb);
            _context.SaveChanges();
            return like;

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

        public Task<Like> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
