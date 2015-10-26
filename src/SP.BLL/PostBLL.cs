using System;
using System.Collections.Generic;
using System.Linq;
using SP.Entities;

namespace SP.BLL
{
    public class PostBLL: IPostBLL
    {
        public Post GetPostById(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostTitles(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> Get(int page, int pageSize)
        {
            
            var post = new Post();
            post.Body =
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more";
            post.Title = "Random Post";
            post.PostedDate = DateTime.Now;

            var listOfPosts = new List<Post>
            {
                post,
                post,
                post
            };
            return listOfPosts.AsEnumerable();

        }

        public IEnumerable<Post> SavePost(Post post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetInactivePosts(int? page)
        {
            throw new NotImplementedException();
        }

        public int GetTotalNumberOfPosts(DateTime? fromDate, DateTime? toDate)
        {
            throw new NotImplementedException();
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
