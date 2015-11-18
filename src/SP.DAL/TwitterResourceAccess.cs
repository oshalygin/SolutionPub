using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using SP.Entities;
using SP.Twitter;
using SP.Twitter.Entities;

namespace SP.DAL
{
    public class TwitterResourceAccess: ITwitterResourceAccess
    {
        private readonly ITwitterApi _twitterApi;
        public TwitterResourceAccess(ITwitterApi twitterApi)
        {
            _twitterApi = twitterApi;
        }
        public IEnumerable<Tweet> Get()
        {
            var timelineList = _twitterApi.GetTimeline();
            var deserializedTimeline =  JsonConvert
                .DeserializeObject<IEnumerable<Timeline>>(timelineList);

            var tweets = deserializedTimeline.Select(timeline => new Tweet
            {
                PostedDate = ParseTwitterDateTime(timeline.CreatedAt),
                Body = timeline.Text
            });

            return tweets;
        }

        private DateTime ParseTwitterDateTime(string twitterDateTime)
        {
            const string twitterDateTimeFormat = "ddd MMM dd HH:mm:ss +ffff yyyy";
            var cultureInfo = new CultureInfo("en-US");

            return DateTime.ParseExact(twitterDateTime, twitterDateTimeFormat, cultureInfo)
                .ToLocalTime();
        }
    }
}
