using System.Collections.Generic;
using Newtonsoft.Json;

namespace SP.Twitter.Entities
{
    public class Description
    {

        [JsonProperty("urls")]
        public List<Url> Urls { get; set; }
    }
}
