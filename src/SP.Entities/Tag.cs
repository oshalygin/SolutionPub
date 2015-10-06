using System.Collections.Generic;

namespace SP.Entities
{
    public sealed class Tag
    {
        public Tag()
        {
            Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimesUsed { get; set; }
        public List<Post> Posts { get; set; }

    }
}
