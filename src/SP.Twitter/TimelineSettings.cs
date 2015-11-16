namespace SP.Twitter
{
    public class TimelineSettings : ITimelineSettings
    {
        public string UserName { get; set; }
        public string IncludeRetweets { get; set; }
        public string ExcludeReplies { get; set; }
        public int Count { get; set; }
        public string TimelineFormat { get; set; }
        public string Url => string.Format(TimelineFormat, UserName, IncludeRetweets, ExcludeReplies, Count);
    }
}