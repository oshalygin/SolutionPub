using System.Collections.Generic;
using SP.DAL;
using SP.Entities;

namespace SP.BLL
{
    public class TagBLL : ITagBLL
    {
        private readonly ITagDataAccess _tagDataAccess;

        public TagBLL(ITagDataAccess tagDataAccess)
        {
            _tagDataAccess = tagDataAccess;
        }

        public Tag GetTag(int tagId)
        {
            return _tagDataAccess
                .GetTag(tagId);
        }

        public Tag GetTag(string tagName)
        {
            return _tagDataAccess
                .GetTag(tagName);
        }

        public IEnumerable<Tag> Get()
        {
            int numberOfTagsToDisplay = 10;

            return _tagDataAccess
                .GetTopTags(numberOfTagsToDisplay);
        }

        public Tag GetMostCommonTag()
        {
            return _tagDataAccess
                .MostCommonTag();
        }

        public Tag IncrementTagUseCounter(Tag tag)
        {
            return _tagDataAccess
                .IncrementTagUseCount(tag);
        }

        public bool RemoveTag(int tagId)
        {
            var rowsUpdated = _tagDataAccess
                .RemoveTag(tagId);

            return rowsUpdated > 0 ? true : false;
        }
    }
}