namespace SP.Twitter
{
    public interface IAuthenticationSettings
    {
        string OauthConsumerKey { get; set; }
        string OauthConsumerSecret { get; set; }
        string OauthUrl { get; set; }
    }
}