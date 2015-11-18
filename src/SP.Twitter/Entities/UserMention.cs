using System.Collections.Generic;
using Newtonsoft.Json;

namespace SP.Twitter.Entities
{
    public class UserMention
    {
        [JsonProperty("screenname")]
        public string ScreenName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }
    }
}
