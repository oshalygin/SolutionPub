namespace SP.Twitter
{
    public class AuthenticationSettings: IAuthenticationSettings
    {
        public string OauthConsumerKey { get; set; }
        public string OauthConsumerSecret { get; set; }
        public string OauthUrl { get; set; }

    }
}
