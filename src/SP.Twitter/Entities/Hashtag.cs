using System.Collections.Generic;
using Newtonsoft.Json;

namespace SP.Twitter.Entities
{
    public class Hashtag
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("indices")]
        public List<int> Indices { get; set; }
    }
}
