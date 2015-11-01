using System;
using System.Collections.Generic;
using SP.Entities;

namespace SP.DAL
{
    public interface IBlogDataAccess
    {
        
        IEnumerable<Post> GetPosts(int page, int pageSize);
        Post GetPost(int postId);
        IEnumerable<Tag> GetTopTags(int maxNumberOfTags);
        IEnumerable<Post> GetRecentPosts(int quantity);
        Post SaveNewPost(Post post);

        int GetTotalNumberOfPosts(DateTime postedStartingDate, DateTime postedEndingDate);

        IEnumerable<Post> GetInactivePosts();


    }
}
