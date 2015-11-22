using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace SP.Twitter
{
    public class TwitterApi : ITwitterApi
    {
        private readonly ITimelineSettings _timelineSettings;
        private readonly IAuthenticationSettings _authenticationSettings;

        //TODO: Hardcoded for now, need to pull from config.json
        public TwitterApi()
        {
            const string baseTwitterConfiguration = "Data:TwitterConfiguration";
            string username;
            string tweetCount;
            string excludeReplies;
            string includeRetweets;
            string timelineFormat;
            string oAuthUrl;
            string oAuthConsumerKey;
            string oAuthConsumerSecret;
            
            var configuration = new ConfigurationBuilder().SetBasePath(@"..\")
                .AddJsonFile("config.json");

            var twitterConfiguration = configuration.Providers.Single();
            _timelineSettings = new TimelineSettings();
            
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:username", out username);
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:count", out tweetCount);
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:excludeReplies", out excludeReplies);
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:includeRetweets", out includeRetweets);
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:timelineFormat", out timelineFormat);
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:oAuthUrl", out oAuthUrl);
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:oAuthConsumerKey", out oAuthConsumerKey);
            twitterConfiguration.TryGet($"{baseTwitterConfiguration}:oAuthConsumerSecret", out oAuthConsumerSecret);

            _timelineSettings.UserName = username;
            _timelineSettings.Count = int.Parse(tweetCount);
            _timelineSettings.ExcludeReplies = excludeReplies;
            _timelineSettings.IncludeRetweets = includeRetweets;
            _timelineSettings.TimelineFormat = timelineFormat;

            _authenticationSettings = new AuthenticationSettings
            {
                OauthUrl = oAuthUrl,
                OauthConsumerKey = oAuthConsumerKey,
                OauthConsumerSecret = oAuthConsumerSecret
            };
            
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