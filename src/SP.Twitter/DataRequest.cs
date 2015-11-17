using System;
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
                var requestUri = new Uri(url);
                var httpRequestMessage = new HttpRequestMessage { Method = HttpMethod.Get };
                httpRequestMessage.Headers.Add("Authorization", $"{tokenType} {accessToken}");
                httpRequestMessage.RequestUri = requestUri;

                var httpResponseMessage = client.SendAsync(httpRequestMessage).Result;
                string response;

                using (var reader = new StreamReader(httpResponseMessage.Content.ReadAsStreamAsync().Result))
                {
                    response = reader.ReadToEnd();
                }

                return response;
            }
        }
    }
}