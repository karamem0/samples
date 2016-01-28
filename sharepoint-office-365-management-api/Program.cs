using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace MyApplication
{

    public static class Program
    {

        private const string TenantId = "{{TenantId}}";

        private const string ClientId = "{{ClientId}}";

        private const string ClientSecret = "{{ClientSecret}}";

        private const string Resource = "https://manage.office.com";

        private const string PublisherIdentifier = "{{PublisherIdentifier}}";

        private static readonly HttpClient HttpClient = new HttpClient();

        private static string AccessToken;

        private static string ContentUri;

        public static void Main(string[] args)
        {
            AcquireToken();
            CreateSubscription();
            GetContentUri();
            GetContents();
        }

        private static void AcquireToken()
        {
            var httpRequestUrl = $"https://login.microsoftonline.com/{TenantId}/oauth2/token";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, httpRequestUrl);
            var httpRequestContent = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                { "grant_type", "client_credentials" },
                { "resource", Resource },
                { "client_id", ClientId },
                { "client_secret", ClientSecret }
            });
            httpRequestMessage.Content = httpRequestContent;
            var httpResponseMessage = HttpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
            var httpResponseContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var httpResponseJson = JsonConvert.DeserializeObject<JToken>(httpResponseContent);
            AccessToken = httpResponseJson.Value<string>("access_token");
        }

        private static void CreateSubscription()
        {
            var httpRequestUrl = $"https://manage.office.com/api/v1.0/{TenantId}/activity/feed/subscriptions/start?contentType=Audit.SharePoint&PublisherIdentifier={PublisherIdentifier}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, httpRequestUrl);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var httpResponseMessage = HttpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
            var httpResponseContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }

        private static void GetContentUri()
        {
            var startTime = DateTime.Today.AddDays(-1).ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss");
            var endTime = DateTime.Today.AddSeconds(-1).ToUniversalTime().ToString("yyyy-MM-dd'T'HH:mm:ss");
            var httpRequestUrl = $"https://manage.office.com/api/v1.0/{TenantId}/activity/feed/subscriptions/content" +
                $"?contentType=Audit.SharePoint" +
                $"&PublisherIdentifier={PublisherIdentifier}" +
                $"&startTime={startTime}" +
                $"&endTime={endTime}";
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestUrl);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var httpResponseMessage = HttpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
            var httpResponseContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var httpResponseJson = JsonConvert.DeserializeObject<JArray>(httpResponseContent);
            ContentUri = httpResponseJson[0].Value<string>("contentUri");
        }

        private static void GetContents()
        {
            var httpRequestUrl = ContentUri;
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, httpRequestUrl);
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            var httpResponseMessage = HttpClient.SendAsync(httpRequestMessage).GetAwaiter().GetResult();
            var httpResponseContent = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var httpResponseJson = JsonConvert.DeserializeObject<JArray>(httpResponseContent);
            Console.WriteLine(JsonConvert.SerializeObject(httpResponseJson, Formatting.Indented));
        }

    }

}
