namespace SP.Twitter
{
    public interface IDataRequest
    {
        string Get(string url, string tokenType, string accessToken);
    }
}
