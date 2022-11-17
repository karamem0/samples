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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Functions
{

    public static class DeleteWebhookFunction
    {

        [FunctionName("DeleteWebhook")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "GET")] HttpRequest req, ILogger log)
        {
            try
            {
                var appConfig = new ApplicationConfiguration();

                var blockBlob = FunctionHelper.GetBlockBlobReference();
                var blockBlobExists = await blockBlob.ExistsAsync();
                if (blockBlobExists == true)
                {
                    var subscriptionId = await blockBlob.DownloadTextAsync();
                    var authResult = await FunctionHelper.GetAuthenticationResult();
                    var graphClient = FunctionHelper.CreateGraphServiceClient(authResult.AccessToken);

                    await graphClient.Subscriptions[subscriptionId]
                        .Request()
                        .DeleteAsync();

                    await blockBlob.DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
            }

            return new OkResult();
        }

    }

}
