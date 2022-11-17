//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Karamem0.SampleApplication.Helpers;
using Karamem0.SampleApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Functions
{

    public static class SubscribeWebhookFunction
    {

        [FunctionName("SubscribeWebhook")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "POST")] HttpRequest req, ILogger log)
        {
            if (req.Query.ContainsKey("validationToken"))
            {
                try
                {
                    var serializer = new JsonSerializer();
                    using (var streamReader = new StreamReader(req.Body))
                    using (var jsonReader = new JsonTextReader(streamReader))
                    {
                        var values = serializer.Deserialize<SubscribeInformationCollection>(jsonReader);
                        foreach (var value in values.Values)
                        {
                            var changeType = value.ChangeType;
                            var resourceId = value.ResourceData.Id;
                            log.LogInformation($"changeType: {changeType}");
                            log.LogInformation($"resourceId: {resourceId}");

                            var authResult = await FunctionHelper.GetAuthenticationResult();
                            var graphClient = FunctionHelper.CreateGraphServiceClient(authResult.AccessToken);

                            var user = await graphClient.Users[resourceId].Request().GetAsync();
                            log.LogInformation($"userPrincipalName: {user.UserPrincipalName}");
                            log.LogInformation($"displayName: {user.DisplayName}");

                        }
                    }
                }
                catch (Exception ex)
                {
                    log.LogError(ex.ToString());
                }
                return new OkResult();
            }
            else
            {
                return new ContentResult()
                {
                    ContentType = "text/plain",
                    Content = req.Query
                        .Where(item => item.Key == "validationToken")
                        .SelectMany(item => item.Value)
                        .FirstOrDefault(),
                    StatusCode = 200
                };
            }
        }

    }

}
