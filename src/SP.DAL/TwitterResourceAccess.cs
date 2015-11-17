using System.Collections.Generic;
using Newtonsoft.Json;
using SP.Entities;
using SP.Twitter;

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
            var timeline = _twitterApi.GetTimeline();
            return JsonConvert.DeserializeObject<IEnumerable<Tweet>>(timeline);
        }
    }
}
