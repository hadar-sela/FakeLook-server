﻿using fakeLook_dal.Data;
using fakeLook_models.Models;
using fakeLook_starter.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fakeLook_starter.Repositories
{
    public class PostRepository : IPostRepository
    {
        readonly private DataContext _context;
        private readonly IDtoConverter _converter;
        private readonly ITagRepository _tagRepository;

        public PostRepository(DataContext context, IDtoConverter converter, ITagRepository tagRepository)
        {
            _context = context;
            _converter = converter;
            _tagRepository = tagRepository;
        }

        public async Task<Post> Add(Post item)
        {
            ICollection<Tag> tags = new List<Tag>();
            if(item.Tags != null)
            foreach (Tag tag in item.Tags)
            {
                tags.Add(_tagRepository.Add(tag).Result);
            }
            item.Tags = tags;
            var res = _context.Posts.Add(item);
            await _context.SaveChangesAsync();
            //return res.Entity;
            return _converter.DtoPost(res.Entity);
        }


        public async Task<Post> Delete(int id)
        {
            var post = _context.Posts.SingleOrDefault(p => p.Id == id);
            if (post == null)
                return null;
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            //return post;
            return _converter.DtoPost(post);
        }

        public async Task<Post> Edit(Post item)
        {
            var post = _context.Posts.FirstOrDefault(p => item.Id == p.Id);
            if (post == null) return null;
            _context.Entry<Post>(post).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();
            //return post;
            return _converter.DtoPost(post);
        }

        public ICollection<Post> GetAll()
        {
            try
            {

                return _context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .ThenInclude(l => l.User)
                    .Include(p => p.Comments)
                    .ThenInclude(c => c.User)
                    .Include(t => t.UserTaggedPost)
                    .Include(t => t.Tags)
                    .Select(DtoLogic).ToList();
            }
            catch (Exception ex)
            {
                var x = 3;
                return new List<Post>();
            }
        }

        private Post DtoLogic(Post p)
        {
            var dtoPost = _converter.DtoPost(p);
            dtoPost.User = _converter.DtoUser(p.User);
            dtoPost.Comments = p.Comments.Select(c =>
            {
                var DtoComment = _converter.DtoComment(c);
                DtoComment.User = _converter.DtoUser(c.User);
                return DtoComment;
            }).ToList();
            dtoPost.Likes = p.Likes.Select(l =>
            {
                var DtoLike = _converter.DtoLike(l);
                DtoLike.User = _converter.DtoUser(l.User);
                return DtoLike;
            }).ToList();
            dtoPost.UserTaggedPost = p.UserTaggedPost.Select(utp =>
            {
                var DtoUserTaggedPost = _converter.DtoUserTaggedPost(utp);
                return DtoUserTaggedPost;
            }).ToList();

            //dtoPost.Tags = p.Tags.ToList();
            dtoPost.Tags = p.Tags.Select(c =>
            {
                var dtoTag = _converter.DtoTag(c);
                return dtoTag;
            }).ToArray();
            return dtoPost;
        }

        public Post GetById(int id)
        {
            return DtoLogic(_context.Posts
                .Include(p => p.User)
                .Include(p => p.Likes)
                .ThenInclude(l => l.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .Include(t => t.UserTaggedPost)
                .Include(t => t.Tags)
                .SingleOrDefault(p => p.Id == id));
        }

        public ICollection<Post> GetByPredicate(Func<Post,bool> predicate)
        {
            //TO - DO ! Return DTO !
            return _context.Posts.Where(predicate).ToList();
        }

    }
}
