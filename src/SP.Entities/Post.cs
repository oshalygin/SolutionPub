using System;
using System.Collections.Generic;

namespace SP.Entities
{
    public sealed class Post
    {
        public Post()
        {
            Tags = new List<Tag>();
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string UrlTitle { get; set; }
        public string PhotoPath { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateEdited { get; set; }
        public string Body { get; set; }
        public string Preview { get; set; }
        public int Views { get; set; }
        public bool Inactive { get; set; }

        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
