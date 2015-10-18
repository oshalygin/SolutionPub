using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SP.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime DateOfComment { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAnonymous { get; set; }

        public virtual Post Post { get; set; }


    }
}
