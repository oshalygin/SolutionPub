using System;
using System.Collections.Generic;

namespace SP.Entities
{
    public class Post
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string PhotoPath { get; set; }
        public DateTime PostedDate { get; set; }
        public DateTime DateEdited { get; set; }
        public string Body { get; set; }
        public string Preview { get; set; }
        public int Views { get; set; }
        public bool Inactive { get; set; }

        public ICollection<PostTag> Tags { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
