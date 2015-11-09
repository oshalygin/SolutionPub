    using System;
using System.Collections.Generic;
using System.Linq;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class PostBLL : IPostBLL
    {
        private readonly IPostDataAccess _postDataAccess;
        private const int Pagesize = 5;

        public PostBLL(IPostDataAccess blogDataAccess)
        {
            _postDataAccess = blogDataAccess;
        }

        public Post GetPostById(int postId)
        {
            return _postDataAccess.GetPost(postId);
        }


        public IEnumerable<Post> GetRecentPosts(int quantity)
        {
            return _postDataAccess
                .GetRecentPosts(quantity);
        }

        public IEnumerable<Post> Get(int page)
        {
            return _postDataAccess
                .GetPosts(page, Pagesize);
        }

        public Post SaveNewPost(Post post)
        {
            return _postDataAccess
                .SaveNewPost(post);
        }

        public IEnumerable<Post> GetInactivePosts()
        {
            return _postDataAccess
                .GetInactivePosts();
        }

        public IEnumerable<Post> GetPostsByDateRange(DateTime? fromDate, DateTime? toDate)
        {
            var postedEndingDate = toDate ?? DateTime.UtcNow.ToLocalTime();
            var postedStartingDate = fromDate ?? DateTime.MinValue;

            return _postDataAccess
                .GetPostsByDateRange(postedStartingDate, postedEndingDate);
        }

        public Post UpdatePost(Post updatedPost)
        {
            return _postDataAccess.UpdatePost(updatedPost);
            
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