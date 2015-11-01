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

        public Tag EditTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteTag(int tagId)
        {
            throw new System.NotImplementedException();
        }

        public Tag SaveTag(Tag tag)
        {
            throw new System.NotImplementedException();
        }
    }
}