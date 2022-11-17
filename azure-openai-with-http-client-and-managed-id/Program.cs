//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Azure.Core;
using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication
{

    public static class Program
    {

        private static readonly string[] Scopes = new[] { "https://cognitiveservices.azure.com/.default" };

        private static readonly string Endpoint = "https://{{resource-name}}.openai.azure.com/openai/deployments/{{deployment-name}}/chat/completions?api-version={{api-version}}";

        private static async Task Main()
        {
            var credential = new DefaultAzureCredential();
            var token = await credential.GetTokenAsync(new TokenRequestContext(Scopes));
            var httpClient = new HttpClient();
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, Endpoint)
            {
                Content = new StringContent(
                    JsonSerializer.Serialize(
                        new Dictionary<string, object>()
                        {
                            ["messages"] = new List<Dictionary<string, object>>()
                            {
                                new Dictionary<string, object>()
                                {
                                    ["role"] = "system",
                                    ["content"] = "あなたは優秀なAIアシスタントです。慎重に考え自信を持って回答してください。"
                                },
                                new Dictionary<string, object>()
                                {
                                    ["role"] = "user",
                                    ["content"] = "日本の首都はどこにありますか？"
                                }
                            }
                        }
                    ),
                    new MediaTypeHeaderValue("application/json"))
            };
            httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            var httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(httpResponseContent);
            Console.ReadLine();
        }

    }

}
