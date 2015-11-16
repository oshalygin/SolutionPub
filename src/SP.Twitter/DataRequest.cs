using System.IO;
using System.Net.Http;

namespace SP.Twitter
{
    public class DataRequest : IDataRequest
    {
        public string Get(string url, string tokenType, string accessToken)
        {
            using (var client = new HttpClient())
            {
                var httpRequestMessage = new HttpRequestMessage { Method = HttpMethod.Get };
                httpRequestMessage.Headers.Add("Authorization", $"{tokenType} {accessToken}");

                var httpResponseMessage = client.SendAsync(httpRequestMessage);
                string response;

                using (var reader = new StreamReader(httpResponseMessage.Result.Content.ReadAsStreamAsync().Result))
                {
                    response = reader.ReadToEnd();
                }

                return response;
            }
        }
    }
}