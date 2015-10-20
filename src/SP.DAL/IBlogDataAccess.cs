using System.Collections.Generic;
using SP.Entities;

namespace SP.DAL
{
    public interface IBlogDataAccess
    {
        
        IEnumerable<Post> GetPosts(int page, int pageSize);
        IEnumerable<Tag> GetTopTags(int maxNumberOfTags);
        IEnumerable<Post> GetLatestPosts(int quantity);


    }
}
