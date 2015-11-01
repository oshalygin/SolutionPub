using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Entity;
using SP.Entities;

namespace SP.DAL
{
    public class BlogDataAccess : IBlogDataAccess
    {
        private readonly BlogContext _context;

        public BlogDataAccess()
        {
            _context = new BlogContext();
        }


        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            return _context
                .Posts
                .Include(x => x.Tags)
                .Include(x => x.Comments)
                .OrderBy(x => x.PostedDate)
                .Skip(page*pageSize)
                .Take(pageSize);
        }

        public Post GetPost(int postId)
        {
            return _context
                .Posts
                .FirstOrDefault(x => x.Id == postId);
        }

        public IEnumerable<Tag> GetTopTags(int maxNumberOfTags)
        {
            return _context
                .Tags
                .OrderBy(x => x.TimesUsed)
                .Take(maxNumberOfTags);
        }

        public IEnumerable<Post> GetRecentPosts(int quantity)
        {
            return _context
                .Posts
                .OrderBy(x => x.PostedDate)
                .Take(quantity);
        }

        public Post SaveNewPost(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
            return post;
        }

        public int GetTotalNumberOfPosts(DateTime postedStartingDate, DateTime postedEndingDate)
        {
            return _context
                .Posts
                .Count(x => x.PostedDate >= postedStartingDate && x.PostedDate <= postedEndingDate);
        }

        public IEnumerable<Post> GetInactivePosts()
        {
            return _context
                .Posts
                .Where(x => x.Inactive);
        }


        public IEnumerable<Tag> GetTags()
        {
            return _context
                .Tags
                .OrderBy(x => x.TimesUsed);
        }

        public Tag EditTag(Tag tag)
        {
            var retrievedTag = _context.Tags.FirstOrDefault(x => x.Id == tag.Id);

            if (retrievedTag == null)
            {
                return null;
            }

            retrievedTag.TimesUsed = tag.TimesUsed;
            retrievedTag.Name = tag.Name;
            _context.SaveChanges();
            return tag;
        }
    }
}