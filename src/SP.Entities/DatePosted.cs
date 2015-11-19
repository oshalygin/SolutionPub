using System;

namespace SP.Entities
{
    public class DatePosted
    {
        public DateTime OriginalPostedDate { get; set; }
        public int WeeksFromPostedDate { get; set; }
        public int DaysFromPostedDate { get; set; }
        public int MinutesFromPostedDate { get; set; }
        public int SecondsFromPostedDate { get; set; }

    }
}
