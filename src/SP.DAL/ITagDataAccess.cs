
using System.Collections.Generic;
using SP.Entities;

namespace SP.DAL
{
    public interface ITagDataAccess
    {
        IEnumerable<Tag> GetTopTags(int maxNumberOfTags);
        Tag EditTag(Tag tag);
    }
}
