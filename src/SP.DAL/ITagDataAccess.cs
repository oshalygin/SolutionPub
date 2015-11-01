
using System.Collections.Generic;
using SP.Entities;

namespace SP.DAL
{
    public interface ITagDataAccess
    {
        IEnumerable<Tag> GetTopTags(int maxNumberOfTags);
        Tag IncrementTagUseCount(Tag tag);
        Tag GetTag(int tagId);
        Tag GetTag(string tagName);
        Tag MostCommonTag();
        int RemoveTag(int tagId);
    }
}
