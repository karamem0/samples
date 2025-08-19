//
// Copyright (c) 2011-2024 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Karamem0.SampleApplication.Helpers;
using Karamem0.SampleApplication.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Functions
{

    public static class UpdateWebhookFunction
    {

        [FunctionName("UpdateWebhook")]
        public static async void Run([TimerTrigger("0 0 * * * *")] TimerInfo timer, ILogger log)
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
                        .UpdateAsync(new Subscription()
                        {
                            ExpirationDateTime = DateTime.Now.AddDays(1),
                        });
                }
            }
            catch (Exception ex)
            {
                log.LogError(ex.ToString());
            }
        }

    }

}
