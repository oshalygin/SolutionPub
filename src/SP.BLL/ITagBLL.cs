using System.Collections.Generic;
using SP.Entities;

namespace SP.BLL
{
    public interface ITagBLL
    {
        Tag GetTagById(int tagId);
        IEnumerable<Tag> Get();
        Tag GetMostCommonTag();
        Tag EditTag(Tag tag);
        bool DeleteTag(int tagId);

        Tag SaveTag(Tag tag);


    }
}
