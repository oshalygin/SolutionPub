using System;

namespace SP.Entities
{
    public class Tweet
    {
        public int Id { get; set; }
        public DatePosted DatePosted { get; set; }
        public string Body { get; set; }
    }
}
