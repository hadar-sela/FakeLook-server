using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class UserTaggedPostRepository : IUserTaggedPostRepository
    {
        readonly private DataContext _context;
        private readonly IDtoConverter _converter;

        public UserTaggedPostRepository(DataContext context, IDtoConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public Task<UserTaggedPost> Add(UserTaggedPost item)
        {
            throw new NotImplementedException();
        }

        public Task<UserTaggedPost> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserTaggedPost> Edit(UserTaggedPost item)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserTaggedPost> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserTaggedPost GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserTaggedPost> GetByPredicate(Func<UserTaggedPost, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
