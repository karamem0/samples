using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using SampleApplication.Helpers;
using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Functions
{

    public static class CreateWebhookFunction
    {

        [FunctionName("CreateWebhook")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "GET")] HttpRequest req, ILogger log)
        {
            try
            {
                var appConfig = new ApplicationConfiguration();

                var blockBlob = FunctionHelper.GetBlockBlobReference();
                var blockBlobExists = await blockBlob.ExistsAsync();
                if (blockBlobExists != true)
                {
                    var authResult = await FunctionHelper.GetAuthenticationResult();
                    var graphClient = FunctionHelper.CreateGraphServiceClient(authResult.AccessToken);

                    var subscription = await graphClient.Subscriptions
                        .Request()
                        .AddAsync(new Subscription()
                        {
                            ChangeType = "updated,deleted",
                            ExpirationDateTime = DateTime.Now.AddDays(1),
                            NotificationUrl = appConfig.GraphSubscribeUrl,
                            Resource = "users"
                        });

                    await blockBlob.UploadTextAsync(subscription.Id);
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
