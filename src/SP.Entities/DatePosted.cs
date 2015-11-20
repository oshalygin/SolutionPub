using System;

namespace SP.Entities
{
    public class DatePosted
    {
        public DateTime OriginalPostedDate { get; set; }
        public long WeeksFromPostedDate { get; set; }
        public long DaysFromPostedDate { get; set; }
        public long HoursFromPostedDate { get; set; }
        public long MinutesFromPostedDate { get; set; }
        public long SecondsFromPostedDate { get; set; }

    }
}
