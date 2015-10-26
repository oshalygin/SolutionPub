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
                .Skip(page * pageSize)
                .Take(pageSize);
        }

        public IEnumerable<Tag> GetTopTags(int maxNumberOfTags)
        {
            return _context
                .Tags
                .OrderBy(x => x.TimesUsed)
                .Take(maxNumberOfTags);
        }

        public IEnumerable<Post> GetLatestPosts(int quantity)
        {
            return _context
                .Posts
                .OrderBy(x => x.PostedDate)
                .Take(quantity);
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