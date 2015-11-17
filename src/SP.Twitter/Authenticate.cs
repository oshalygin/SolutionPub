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


            var authenticationConsumerKey = Uri.EscapeDataString(authenticationSettings.OauthConsumerKey);
            var authenticationConsumerSecret = Uri.EscapeDataString(authenticationSettings.OauthConsumerSecret);
            var byteEncodedConsumerAuthentication =
                Encoding.UTF8.GetBytes(authenticationConsumerKey + ":" + authenticationConsumerSecret);
            var convertedConsumerAuthentication = Convert.ToBase64String(byteEncodedConsumerAuthentication);

            var authenticationHeader = $"Basic {convertedConsumerAuthentication}";
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