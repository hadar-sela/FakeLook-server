using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class TagRepository : ITagRepository
    {
        readonly private DataContext _context;
        private readonly IDtoConverter _converter;

        public TagRepository(DataContext context, IDtoConverter converter)
        {
            _context = context;
            _converter = converter;
        }

        public async Task<Tag> Add(Tag item)
        {
            var res = GetByContent(item.Content);
            if (res == null)
            {
                res = _context.Tags.Add(item).Entity;
                await _context.SaveChangesAsync();
            }
            return res;
            //var res = _context.Tags.Add(item);
            //await _context.SaveChangesAsync();
            //return res.Entity;
        }

        private Tag GetByContent(string content)
        {

            if(content == null)
                return null;
            try
            {

                var res = _context.Tags.Where(t => content == t.Content).FirstOrDefault();
                return res;
            }
            catch (Exception ex)
            {

                var x = 3;
            }
            return null;
        }

        public Task<Tag> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tag> Edit(Tag item)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetAll()
        {
            return _context.Tags.ToList();
        }

        public Tag GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Tag> GetByPredicate(Func<Tag, bool> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
