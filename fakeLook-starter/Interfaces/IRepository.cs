using fakeLook_models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Interfaces
{
    public interface IRepository<T>
    {
        public Task<T> Add(T item);
        public ICollection<T> GetAll();
        public Task<T> Edit(T item);
        public T GetById(int id);
        public Task<T> Delete(int id);
        public ICollection<T> GetByPredicate(Func<T, bool> predicate);
    }
    public interface IUserRepository : IRepository<User>
    {
        public User GetByUserBirth(User user);
        public User GetByUser(User user);
    }
    public interface IPostRepository : IRepository<Post>
    {
        ICollection<Post> GetByFilters(Filter filtersList);
    }
    public interface ILikeRepository: IRepository<Like>
    {

    }
    public interface ICommentRepository: IRepository<Comment>
    {

    }
    public interface ITagRepository: IRepository<Tag>
    {

    }
    public interface IUserTaggedCommentRepository: IRepository<UserTaggedComment>
    {

    }
    public interface IUserTaggedPostRepository: IRepository<UserTaggedPost>
    {

    }
}
