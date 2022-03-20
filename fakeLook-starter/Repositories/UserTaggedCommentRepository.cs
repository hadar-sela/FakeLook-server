using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class UserTaggedCommentRepository : IUserTaggedCommentRepository
    {
        readonly private DataContext _context;
        private readonly IDtoConverter _converter;

        public UserTaggedCommentRepository(DataContext context, IDtoConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public Task<UserTaggedComment> Add(UserTaggedComment item)
        {
            throw new NotImplementedException();
        }

        public Task<UserTaggedComment> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserTaggedComment> Edit(UserTaggedComment item)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserTaggedComment> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserTaggedComment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserTaggedComment> GetByPredicate(Func<UserTaggedComment, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
