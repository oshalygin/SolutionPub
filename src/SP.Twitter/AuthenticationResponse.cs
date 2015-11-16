using Newtonsoft.Json;

namespace SP.Twitter
{
    public class AuthenticationResponse
    {
        [JsonProperty("token_type")]
        public string TokenType { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

    }
}
