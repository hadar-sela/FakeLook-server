﻿using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task<Tag> Add(Tag item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
