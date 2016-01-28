using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Helpers
{

    public static class FunctionHelper
    {

        public static CloudBlockBlob GetBlockBlobReference()
        {
            var appConfig = new ApplicationConfiguration();
            var storageAccount = CloudStorageAccount.Parse(appConfig.GraphBlobStorage);
            var blobClient = storageAccount.CreateCloudBlobClient();
            var blobContainer = blobClient.GetContainerReference(appConfig.GraphBlobContainer);
            return blobContainer.GetBlockBlobReference("subscriptionid");
        }

        public static async Task<AuthenticationResult> GetAuthenticationResult()
        {
            var appConfig = new ApplicationConfiguration();
            var clientCred = new ClientCredential(appConfig.GraphClientSecret);
            var clientApp = new ConfidentialClientApplication(
                appConfig.GraphClientId,
                $"{appConfig.GraphAuthority}/{appConfig.GraphTenantId}",
                appConfig.GraphRedirectUrl,
                clientCred,
                null,
                null);
            return await clientApp.AcquireTokenForClientAsync(appConfig.GraphScope.Split(","));
        }

        public static GraphServiceClient CreateGraphServiceClient(string accessToken)
        {
            return new GraphServiceClient(new DelegateAuthenticationProvider(async msg =>
            {
                await Task.Run(() =>
                {
                    msg.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                });
            }));
        }

    }

}
