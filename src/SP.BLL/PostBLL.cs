using System;
using System.Collections.Generic;
using System.Linq;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class PostBLL: IPostBLL
    {

        private readonly IBlogDataAccess _blogDataAccess;

        public PostBLL(IBlogDataAccess blogDataAccess)
        {
            _blogDataAccess = blogDataAccess;
        }
        
        readonly int _pagesize = 5;
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


            var post = new Post
            {
                Body =
                    "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more",
                Title = "Random Post",
                PostedDate = DateTime.Now
            };

            var listOfPosts = new List<Post>
            {
                post,
                post,
                post
            };
            return listOfPosts.AsEnumerable();

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
