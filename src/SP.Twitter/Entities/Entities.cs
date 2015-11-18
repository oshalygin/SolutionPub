using System.Collections.Generic;
using Newtonsoft.Json;

namespace SP.Twitter.Entities
{
    public class Entities
    {
        [JsonProperty("hashtags")]
        public List<Hashtag> Hashtags { get; set; }

        [JsonProperty("symbols")]
        public List<string> Symbols { get; set; }

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }

        [JsonProperty("user_mentions")]
        public List<UserMention> UserMentions { get; set; }

        [JsonProperty("media")]
        public List<Media> Media { get; set; }
    }
}
