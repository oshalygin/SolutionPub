using System.Collections.Generic;

namespace SP.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimesUsed { get; set; }
        public ICollection<PostTag> Posts { get; set; }

    }
}
