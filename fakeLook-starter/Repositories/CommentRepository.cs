using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        readonly private DataContext _context;
        private readonly IDtoConverter _converter;

        public CommentRepository(DataContext context, IDtoConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<Comment> Add(Comment item)
        {
            var res = _context.Comments.Add(item);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public Task<Comment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> Edit(Comment item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Comment> GetByPredicate(Func<Comment, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
