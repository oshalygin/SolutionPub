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
        IEnumerable<Post> GetPostsByDateRange(DateTime? fromDate, DateTime? toDate);
        Post UpdatePost(Post updatedPost);
        bool DeletePost(int postId);

        Post GetPostByUrlTitle(string postUrlTitle);


    }
}
