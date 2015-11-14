using System;

namespace SP.WEB.Models
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public DateTime PostedDate { get; set; }
        public string Body { get; set; }
    }
}
