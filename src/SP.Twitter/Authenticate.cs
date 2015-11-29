using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace SP.Twitter
{
    public class Authenticate : IAuthenticate
    {
        private const string PostBody = "grant_type=client_credentials";
        private const string BasicAuthentication = "Basic";

        public AuthenticationResponse AuthenticateUser(IAuthenticationSettings authenticationSettings)
        {
            var authenticationHeader = ConstructAuthenticationHeader(authenticationSettings);
            var authenticationUrl = authenticationSettings.OauthUrl;

            var httpClientHandler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            return SendHttpRequest(httpClientHandler, authenticationHeader, authenticationUrl);
        }

        private static AuthenticationResponse SendHttpRequest(HttpClientHandler httpClientHandler,
            string authenticationHeader, string authenticationUrl)
        {
            using (var client = new HttpClient(httpClientHandler))
            {
                var httpRequestMessage = new HttpRequestMessage();

                var requestUri = new Uri(authenticationUrl);

                httpRequestMessage.RequestUri = requestUri;
                httpRequestMessage.Headers.Add("Authorization", authenticationHeader);
                httpRequestMessage.Method = HttpMethod.Post;

                var content = Encoding.UTF8.GetBytes(PostBody);
                var stream = new MemoryStream(content, 0, content.Length);

                httpRequestMessage.Content = new StreamContent(stream);

                httpRequestMessage.Content.Headers.ContentType =
                    MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded; charset=utf-8");

                httpRequestMessage.Headers.Add("Accept-Encoding", "gzip");
                var httpResponseMessage = client.SendAsync(httpRequestMessage).Result;

                return DeserializeTwitterResponse(httpResponseMessage);
            }
        }


        private static string ConstructAuthenticationHeader(IAuthenticationSettings authenticationSettings)
        {
            var authenticationConsumerKey = Uri.EscapeDataString(authenticationSettings.OauthConsumerKey);
            var authenticationConsumerSecret = Uri.EscapeDataString(authenticationSettings.OauthConsumerSecret);
            var byteEncodedConsumerAuthentication =
                Encoding.UTF8.GetBytes(authenticationConsumerKey +
                                       ":" + authenticationConsumerSecret);
            var convertedConsumerAuthentication = Convert.ToBase64String(byteEncodedConsumerAuthentication);

            return $"{BasicAuthentication} {convertedConsumerAuthentication}";
        }

        private static AuthenticationResponse DeserializeTwitterResponse(HttpResponseMessage httpResponseMessage)
        {
            using (httpResponseMessage)
            {
                using (var reader = new StreamReader(httpResponseMessage.Content.ReadAsStreamAsync().Result))
                {
                    var objectBody = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<AuthenticationResponse>(objectBody);
                }
            }
        }
    }
}