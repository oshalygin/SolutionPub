using System.Collections.Generic;
using SP.Entities;
using System.Linq;

namespace SP.DAL
{
    public class TagDataAccess: ITagDataAccess
    {

        private readonly BlogContext _context;

        public TagDataAccess()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Tag> GetTopTags(int maxNumberOfTags)
        {
            return _context
                .Tags
                .OrderBy(x => x.TimesUsed)
                .Take(maxNumberOfTags);
        }
        public Tag EditTag(Tag tag)
        {
            var retrievedTag = _context.Tags.FirstOrDefault(x => x.Id == tag.Id);

            if (retrievedTag == null)
            {
                return null;
            }

            retrievedTag.TimesUsed = tag.TimesUsed;
            retrievedTag.Name = tag.Name;
            _context.SaveChanges();
            return tag;
        }
    }
}
