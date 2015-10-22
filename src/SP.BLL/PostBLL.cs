using System;
using System.Collections.Generic;
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

        public IEnumerable<Post> Get(int? page)
        {
            throw new NotImplementedException();
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
