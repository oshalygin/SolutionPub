using System;
using System.Collections.Generic;
using System.Linq;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class PostBLL : IPostBLL
    {
        private readonly IPostDataAccess _blogDataAccess;
        private const int Pagesize = 5;

        public PostBLL(IPostDataAccess blogDataAccess)
        {
            _blogDataAccess = blogDataAccess;
        }

        public Post GetPostById(int postId)
        {
            return _blogDataAccess.GetPost(postId);
        }


        public IEnumerable<Post> GetRecentPosts(int quantity)
        {
            return _blogDataAccess
                .GetRecentPosts(quantity);
        }

        public IEnumerable<Post> Get(int page)
        {
            return _blogDataAccess
                .GetPosts(page, Pagesize);
        }

        public Post SaveNewPost(Post post)
        {
            return _blogDataAccess
                .SaveNewPost(post);
        }

        public IEnumerable<Post> GetInactivePosts()
        {
            return _blogDataAccess
                .GetInactivePosts();
        }

        public int GetTotalNumberOfPosts(DateTime? fromDate, DateTime? toDate)
        {
            var postedEndingDate = toDate ?? DateTime.UtcNow.ToLocalTime();
            var postedStartingDate = fromDate ?? DateTime.MinValue;

            return _blogDataAccess
                .GetTotalNumberOfPosts(postedStartingDate, postedEndingDate);
        }

        public Post EditPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Post DeactivatePost(int postId)
        {
            throw new NotImplementedException();
        }

        public bool DeletePost(int postId)
        {
            throw new NotImplementedException();
        }
    }
}