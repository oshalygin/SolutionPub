using System;
using System.Collections.Generic;
using SP.Entities;

namespace SP.BLL
{
    public interface IPostBLL
    {
        Post GetPostById(int postId);
        IEnumerable<Post> GetPostTitles(int quantity);
        IEnumerable<Post> Get(int page);
        IEnumerable<Post> SavePost(Post post);
        IEnumerable<Post> GetInactivePosts(int? page);
        int GetTotalNumberOfPosts(DateTime? fromDate, DateTime? toDate);
        Post EditPost(Post post);
        Post DeactivatePost(int postId);
        bool DeletePost(int postId);


    }
}
