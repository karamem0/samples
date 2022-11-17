//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Azure.Identity;
using Azure.Storage.Blobs;
using Karamem0.SampleApplication.Models;
using Karamem0.SampleApplication.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System.Security.Cryptography.X509Certificates;
using Constants = Karamem0.SampleApplication.Constants;

var builder = FunctionsApplication.CreateBuilder(args);

_ = builder.ConfigureFunctionsWebApplication();

var configuration = builder.Configuration;
_ = configuration.AddJsonFile(
    "appsettings.json",
    true,
    true
);
_ = configuration.AddUserSecrets(typeof(Program).Assembly, true);
_ = configuration.AddEnvironmentVariables();

var services = builder.Services;

_ = services.AddApplicationInsightsTelemetryWorkerService();
_ = services.ConfigureFunctionsApplicationInsights();

_ = services.AddSingleton(provider =>
    {
        var options = configuration
            .GetSection("AzureStorageBlobs")
            .Get<AzureStorageBlobsOptions>();
        _ = options ?? throw new InvalidOperationException();
        var blobServiceClient = new BlobServiceClient(options.Endpoint, new DefaultAzureCredential());
        var blobContainerClient = blobServiceClient.GetBlobContainerClient(options.ContainerName);
        return blobContainerClient;
    }
);
_ = services.AddSingleton(provider =>
    {
        var options = configuration
            .GetSection("MicrosoftIdentity")
            .Get<MicrosoftIdentityOptions>();
        _ = options ?? throw new InvalidOperationException();
        var certificate = X509Certificate2.CreateFromPemFile(Constants.CrtPemPath, Constants.KeyPemPath);
        var credential = new ClientCertificateCredential(
            options.TenantId,
            options.ClientId,
            certificate
        );
        return new GraphServiceClient(credential);
    }
);
_ = services.AddSingleton<IBlobsService, BlobsService>();
_ = services.AddSingleton<IEncryptionService, EncryptionService>();
_ = services.AddSingleton<IGraphService, GraphService>();

var app = builder.Build();

await app.RunAsync();
