namespace SP.Twitter
{
    public interface ITimelineSettings
    {
        string UserName { get; set; }
        string IncludeRetweets { get; set; }
        string ExcludeReplies { get; set; }
        int Count { get; set; }
        string TimelineFormat { get; set; }
        string Url { get; }
    }
}