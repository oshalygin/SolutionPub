using System.Collections.Generic;
using SP.Entities;

namespace SP.BLL
{
    public interface ITagBLL
    {
        Tag GetTag(int tagId);
        Tag GetTag(string tagName);
        IEnumerable<Tag> Get();
        Tag GetMostCommonTag();
        Tag IncrementTagUseCounter(Tag tag);
        bool RemoveTag(int tagId);
    }
}