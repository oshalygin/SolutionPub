using System.Collections.Generic;

namespace SP.Entities
{
    public sealed class Tag
    {
        public Tag()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimesUsed { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
