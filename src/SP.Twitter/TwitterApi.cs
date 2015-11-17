namespace SP.Twitter
{
    public class TwitterApi : ITwitterApi
    {
        private readonly ITimelineSettings _timelineSettings;
        private readonly IAuthenticationSettings _authenticationSettings;

        //TODO: Hardcoded for now, need to pull from config.json
        public TwitterApi()
        {
            _timelineSettings = new TimelineSettings();
            _timelineSettings.UserName = "oshalygin";
            _timelineSettings.Count = 3;
            _timelineSettings.ExcludeReplies = "0";
            _timelineSettings.IncludeRetweets = "1";
            _timelineSettings.TimelineFormat =
                @"https://api.twitter.com/1.1/statuses/user_timeline.json?screen_name={0}&amp;include_rts={1}&amp;exclude_replies={2}&amp;count={3}";

            _authenticationSettings = new AuthenticationSettings();
            _authenticationSettings.OauthUrl = @"https://api.twitter.com/oauth2/token";
            _authenticationSettings.OauthConsumerKey = "QaM8auViHNQCp1JhB9Mpo6u1F";
            _authenticationSettings.OauthConsumerSecret = "15NYd2AKxkL9Vix3xBRUPsKhb0Znxodg019Wv2jCzL3qQBZZ2l";
        }

        public string GetTimeline()
        {
            var authenticate = new Authenticate();
            var authenticationResponse = authenticate.AuthenticateUser(_authenticationSettings);

            var twitterData = new DataRequest();
            return twitterData.Get(_timelineSettings.Url, authenticationResponse.TokenType,
                authenticationResponse.AccessToken);
        }
    }
}