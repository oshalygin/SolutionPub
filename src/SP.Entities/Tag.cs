using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Entities
{
    public class Tag
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
