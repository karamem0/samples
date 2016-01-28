using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.Samples
{

    public static class Program
    {

        private static readonly string OAuthTokenUri = "https://login.microsoftonline.com/common/oauth2/token";

        private static readonly string ClientId = "{{clientid}}";

        private static readonly string UserName = "{{username}}";

        private static readonly string Password = "{{password}}";

        private static readonly string SharePointUri = "https://{{tenantname}}.sharepoint.com";

        private static void Main()
        {
            var httpClient = new HttpClient();

            var authRequestContent = "grant_type=password"
                + "&" + "username=" + Uri.EscapeDataString(UserName)
                + "&" + "password=" + Uri.EscapeDataString(Password)
                + "&" + "resource=" + Uri.EscapeDataString(SharePointUri)
                + "&" + "client_id=" + Uri.EscapeDataString(ClientId);
            var authRequestMessage = new HttpRequestMessage(HttpMethod.Post, OAuthTokenUri);
            authRequestMessage.Content = new StringContent(authRequestContent, Encoding.UTF8, "application/x-www-form-urlencoded");
            authRequestMessage.Headers.Add("Accept", "application/json");
            var authResponseMessage = httpClient.SendAsync(authRequestMessage).GetAwaiter().GetResult();
            var authResponseContent = authResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var authResponseJson = JsonConvert.DeserializeObject<JObject>(authResponseContent);

            var listRequestMessage = new HttpRequestMessage(HttpMethod.Get, SharePointUri + "/_api/web/lists");
            listRequestMessage.Headers.Add("Accept", "application/json");
            listRequestMessage.Headers.Add("Authorization", "Bearer " + authResponseJson["access_token"]);
            var listResponseMessage = httpClient.SendAsync(listRequestMessage).GetAwaiter().GetResult();
            var listResponseContent = listResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

            Console.WriteLine(listResponseContent);
            Console.ReadLine();
        }

    }

}
