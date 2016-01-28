using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace SampleApplication
{

    public static class Program
    {

        private static readonly string TenantId = "{{tenantid}}";

        private static readonly string ClientId = "{{clientid}}";

        private static readonly string ClientSecret = "{{clientsecret}}";

        private static readonly string Scopes = "https://graph.microsoft.com/.default";

        private static readonly HttpClient HttpClient = new HttpClient();

        private static void Main(string[] args)
        {
            var clientApplication = ConfidentialClientApplicationBuilder
                .Create(ClientId).WithTenantId(TenantId).WithClientSecret(ClientSecret).Build();
            var authenticationResult = clientApplication
                .AcquireTokenForClient(Scopes.Split(',')).ExecuteAsync().GetAwaiter().GetResult();
            var accessToken = authenticationResult.AccessToken;
            GetOAuth2PermissionGrants(accessToken).Value<JArray>("value")
                .Select(item =>
                {
                    var client = GetServicePrincipal(item.Value<string>("clientId"), accessToken);
                    var resource = GetServicePrincipal(item.Value<string>("resourceId"), accessToken);
                    var user = item.Value<string>("consentType") == "Principal"
                        ? GetUser(item.Value<string>("principalId"), accessToken)
                        : null;
                    return new
                    {
                        ClientId = client.Value<string>("id"),
                        ClientName = client.Value<string>("appDisplayName"),
                        ResourceId = resource.Value<string>("id"),
                        ResourceName = resource.Value<string>("appDisplayName"),
                        UserId = user?.Value<string>("id"),
                        UserName = user?.Value<string>("displayName"),
                        Scope = item.Value<string>("scope"),
                    };
                })
                .ToList()
                .ForEach(item =>
                {
                    Console.WriteLine($"ClientId     : {item.ClientId}");
                    Console.WriteLine($"ClientName   : {item.ClientName}");
                    Console.WriteLine($"ResourceId   : {item.ResourceId}");
                    Console.WriteLine($"ResourceName : {item.ResourceName}");
                    Console.WriteLine($"UserId       : {item.UserId}");
                    Console.WriteLine($"UserName     : {item.UserName}");
                    Console.WriteLine($"Scope        : {item.Scope.Trim()}");
                    Console.WriteLine();
                });
        }

        private static JToken GetOAuth2PermissionGrants(string accessToken)
        {
            var requestUrl = "https://graph.microsoft.com/beta/oAuth2PermissionGrants";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseMessage = HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseJson = JsonConvert.DeserializeObject<JToken>(responseContent);
            return responseJson;
        }

        private static JToken GetServicePrincipal(string id, string accessToken)
        {
            var requestUrl = $"https://graph.microsoft.com/beta/servicePrincipals/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseMessage = HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseJson = JsonConvert.DeserializeObject<JToken>(responseContent);
            return responseJson;
        }

        private static JToken GetUser(string id, string accessToken)
        {
            var requestUrl = $"https://graph.microsoft.com/beta/users/{id}";
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseMessage = HttpClient.SendAsync(requestMessage).GetAwaiter().GetResult();
            var responseContent = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseJson = JsonConvert.DeserializeObject<JToken>(responseContent);
            return responseJson;
        }

    }

}
