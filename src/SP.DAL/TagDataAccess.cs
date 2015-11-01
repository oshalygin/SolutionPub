using System;
using System.Collections.Generic;
using SP.Entities;
using System.Linq;
using Microsoft.Data.Entity;

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
        public Tag IncrementTagUseCount(Tag tag)
        {
            var retrievedTag = _context.Tags.FirstOrDefault(x => 
                string.Equals(x.Name, tag.Name, 
                StringComparison.CurrentCultureIgnoreCase));
                
            if (retrievedTag == null)
            {
                return null;
            }

            retrievedTag.TimesUsed += 1;
            _context.Entry(retrievedTag).State = EntityState.Modified;            
            _context.SaveChanges();
            return retrievedTag;
        }

        public Tag GetTag(int tagId)
        {
            return _context
                .Tags
                .Single(x => x.Id == tagId);
        }

        public Tag GetTag(string tagName)
        {
            return _context
                .Tags
                .Single(x => string.Equals(x.Name, tagName, 
                StringComparison.CurrentCultureIgnoreCase));
        }

        public Tag MostCommonTag()
        {
            return _context
                .Tags
                .OrderByDescending(x => x.TimesUsed)
                .First();

        }

        public int RemoveTag(int tagId)
        {
            var tagToRemove = _context
                .Tags
                .Single(x => x.Id == tagId);
            _context.Remove(tagToRemove);
            return _context.SaveChanges();
            
        }
    }
}
