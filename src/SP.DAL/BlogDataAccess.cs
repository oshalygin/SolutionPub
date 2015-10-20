using System.Collections.Generic;
using SP.Entities;

namespace SP.DAL
{
    public class BlogDataAccess: IBlogDataAccess
    {
        private readonly BlogContext _context;

        public BlogDataAccess()
        {
            _context = new BlogContext();
        }


        public IEnumerable<Post> GetPosts(int page, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Tag> GetTopTags(int maxNumberOfTags)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPosts(int quantity)
        {
            throw new System.NotImplementedException();
        }
    }

}
