using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using SampleApplication.Helpers;
using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Functions
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
