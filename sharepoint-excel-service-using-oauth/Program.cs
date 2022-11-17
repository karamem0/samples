//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SampleApplication.Properties;
using SampleApplication.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication
{

    public static class Program
    {

        private static readonly string TenantName = "{{tenant-name}}";

        private static readonly string ClientId = "{{client-id}}";

        private static readonly string ResourceUri = $"https://{TenantName}.sharepoint.com";

        private static readonly string DeviceCodeUri = $"https://login.microsoftonline.com/{TenantName}.onmicrosoft.com/oauth2/devicecode";

        private static readonly string TokenUri = $"https://login.microsoftonline.com/{TenantName}.onmicrosoft.com/oauth2/token";

        private static readonly string ExcelServiceUri = $"{ResourceUri}/_vti_bin/ExcelService.asmx";

        private static readonly string FilePath = $"{ResourceUri}/Shared%20Documents/Book.xlsx";

        private static readonly DateTime ExpiresOnBase = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        private static void Main(string[] args)
        {
            Execute().Wait();
        }

        private static async Task Execute()
        {
            if (string.IsNullOrEmpty(Settings.Default.AccessToken))
            {
                var jsonDeviceCode = await GetDeviceCode();
                var message = jsonDeviceCode["message"];
                var deviceCode = jsonDeviceCode["device_code"];
                Console.WriteLine(message);
                Console.ReadLine();
                var jsonToken = await GetTokenByDeviceCode(deviceCode);
                var accessToken = jsonToken["access_token"];
                var refreshToken = jsonToken["refresh_token"];
                var expiresOn = ExpiresOnBase.AddSeconds(double.Parse(jsonToken["expires_on"]));
                Settings.Default.AccessToken = accessToken;
                Settings.Default.RefreshToken = refreshToken;
                Settings.Default.ExpiresOn = expiresOn;
                Settings.Default.Save();
            }
            else if (Settings.Default.ExpiresOn <= DateTime.UtcNow)
            {
                var jsonToken = await GetTokenByRefreshToken(Settings.Default.RefreshToken);
                var accessToken = jsonToken["access_token"];
                var refreshToken = jsonToken["refresh_token"];
                var expiresOn = ExpiresOnBase.AddSeconds(double.Parse(jsonToken["expires_on"]));
                Settings.Default.AccessToken = accessToken;
                Settings.Default.RefreshToken = refreshToken;
                Settings.Default.ExpiresOn = expiresOn;
                Settings.Default.Save();
            }
            Console.WriteLine(ReadCellValue());
            Console.ReadLine();
        }

        private static async Task<Dictionary<string, string>> GetDeviceCode()
        {
            var httpClient = new HttpClient();
            var requestUri = DeviceCodeUri
                + "?" + "resource=" + Uri.EscapeDataString(ResourceUri)
                + "&" + "client_id=" + Uri.EscapeDataString(ClientId);
            var responseBody = await httpClient.GetStringAsync(requestUri);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);
        }

        private static async Task<Dictionary<string, string>> GetTokenByDeviceCode(string deviceCode)
        {
            var httpClient = new HttpClient();
            var requestUri = TokenUri;
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            requestMessage.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            requestMessage.Content = new StringContent(
                "grant_type=device_code"
                 + "&" + "resource=" + Uri.EscapeDataString(ResourceUri)
                 + "&" + "client_id=" + Uri.EscapeDataString(ClientId)
                 + "&" + "code=" + Uri.EscapeDataString(deviceCode),
                Encoding.UTF8, "application/x-www-form-urlencoded");
            var responseMessage = await httpClient.SendAsync(requestMessage);
            var responseBody = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);
        }

        private static async Task<Dictionary<string, string>> GetTokenByRefreshToken(string refreshToken)
        {
            var httpClient = new HttpClient();
            var requestUri = TokenUri;
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
            requestMessage.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
            requestMessage.Content = new StringContent(
                "grant_type=refresh_token"
                 + "&" + "resource=" + Uri.EscapeDataString(ResourceUri)
                 + "&" + "client_id=" + Uri.EscapeDataString(ClientId)
                 + "&" + "refresh_token=" + Uri.EscapeDataString(refreshToken),
                Encoding.UTF8, "application/x-www-form-urlencoded");
            var responseMessage = await httpClient.SendAsync(requestMessage);
            var responseBody = await responseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(responseBody);
        }

        private static string ReadCellValue()
        {
            var cellValue = default(object);
            using (var client = new ExcelServiceSoapClient())
            {
                client.Endpoint.EndpointBehaviors.Add(new BearerEndpointBehavior());
                var status = default(Status[]);
                var sessionId = client.OpenWorkbook(FilePath, "", "", out status);
                cellValue = client.GetCellA1(sessionId, "Sheet1", "A1", false, out status);
                client.CloseWorkbook(sessionId);
            }
            return cellValue.ToString();
        }

    }

}
