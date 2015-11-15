using System;

namespace SP.Entities
{
    public class Tweet
    {
        public int Id { get; set; }
        public DateTime PostedDate { get; set; }
        public string Body { get; set; }
    }
}
