using Newtonsoft.Json;

namespace SP.Twitter.Entities
{
    public class UserEntities
    {
        [JsonProperty("description")]
        public Description Description { get; set; }
    }
}
