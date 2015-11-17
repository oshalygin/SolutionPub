using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace SP.Twitter
{
    //TODO: Refactor this into reusable components once this is confirmed to work.
    public class Authenticate : IAuthenticate
    {
        public AuthenticationResponse AuthenticateUser(IAuthenticationSettings authenticationSettings)
        {
            var response = new AuthenticationResponse();

            var escapedConsumerKey = Uri.EscapeDataString(authenticationSettings.OauthConsumerKey);
            var byteEncodedConsumerKey = Encoding.UTF8.GetBytes(escapedConsumerKey);
            var authenticationConsumerKey = Convert.ToBase64String(byteEncodedConsumerKey);

            var authenticationConsumerSecret = Uri.EscapeDataString(authenticationSettings.OauthConsumerSecret);

            var authenticationHeader = $"Basic {authenticationConsumerKey}:{authenticationConsumerSecret}";
            var postBody = "grant_type=client_credentials";

            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            using (var client = new HttpClient(httpClientHandler))
            {
                var httpRequestMessage = new HttpRequestMessage();

                var requestUri = new Uri(authenticationSettings.OauthUrl);

                httpRequestMessage.RequestUri = requestUri;
                httpRequestMessage.Headers.Add("Authorization", authenticationHeader);
                httpRequestMessage.Method = HttpMethod.Post;

                var content = Encoding.UTF8.GetBytes(postBody);
                var stream = new MemoryStream(content, 0, content.Length);

                httpRequestMessage.Content = new StreamContent(stream);

                httpRequestMessage.Content.Headers.ContentType =
                    MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded; charset=utf-8");

                httpRequestMessage.Headers.Add("Accept-Encoding", "gzip");
                var httpResponseMessage = client.SendAsync(httpRequestMessage).Result;

                using (httpResponseMessage)
                {
                    using (var reader = new StreamReader(httpResponseMessage.Content.ReadAsStreamAsync().Result))
                    {
                        var objectBody = reader.ReadToEnd();
                        response = JsonConvert.DeserializeObject<AuthenticationResponse>(objectBody);
                    }
                }

                return response;
            }
        }
    }
}