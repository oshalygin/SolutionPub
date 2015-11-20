using System;

namespace SP.WEB.Models
{
    public class TweetViewModel
    {
        public int Id { get; set; }
        public DateTime OriginalPostedDate { get; set; }
        public long WeeksFromPostedDate { get; set; }
        public long DaysFromPostedDate { get; set; }
        public long HoursFromPostedDate { get; set; }
        public long MinutesFromPostedDate { get; set; }
        public long SecondsFromPostedDate { get; set; }
        public string Body { get; set; }
    }
}
