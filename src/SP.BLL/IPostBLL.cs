using System;
using System.Collections.Generic;
using SP.Entities;

namespace SP.BLL
{
    public interface IPostBLL
    {
        Post GetPostById(int postId);
        IEnumerable<Post> GetRecentPosts(int quantity);
        IEnumerable<Post> Get(int page);
        Post SaveNewPost(Post post);
        IEnumerable<Post> GetInactivePosts();
        IEnumerable<Post> GetPostsByDateRange(DateTime? fromDate, DateTime? toDate);
        Post EditPost(Post post);
        Post DeactivatePost(int postId);
        bool DeletePost(int postId);


    }
}
