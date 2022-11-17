//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

#pragma warning disable IDE0060

using Karamem0.SampleApplication.Logging;
using Karamem0.SampleApplication.Models;
using Karamem0.SampleApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Karamem0.SampleApplication.Functions;

public class CreateSubscriptionFunction(
    ILogger<CreateSubscriptionFunction> logger,
    IGraphService graphService,
    IBlobsService blobsService
)
{

    private readonly ILogger<CreateSubscriptionFunction> logger = logger;

    private readonly IGraphService graphService = graphService;

    private readonly IBlobsService blobsService = blobsService;

    [Function("CreateSubscription")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Admin, "POST")] HttpRequest httpRequest)
    {
        try
        {
            this.logger.MethodExecuting();
            // サブスクリプションを作成する
            var baseUrl = new Uri(httpRequest.GetDisplayUrl()).GetLeftPart(UriPartial.Authority);
            var notificationUrl = $"{baseUrl}/api/ReceiveSubscription?code={httpRequest.Query["code"]}";
            var encryptionCertificateId = Guid
                .NewGuid()
                .ToString();
            var clientState = Guid
                .NewGuid()
                .ToString();
            var subscription = await this.graphService.CreateSubscriptionAsync(
                notificationUrl,
                encryptionCertificateId,
                clientState
            );
            // サブスクリプション情報を設定ファイルとして保存する
            var settings = new ChangeNotificationSettings()
            {
                SubscriptionId = subscription.Id!,
                EncryptionCertificateId = encryptionCertificateId,
                ClientState = clientState
            };
            await this.blobsService.SetSettingsAsync(settings);
            return new OkObjectResult(settings);
        }
        catch (InvalidOperationException ex)
        {
            this.logger.MethodFailed(exception: ex);
            return new StatusCodeResult(StatusCodes.Status400BadRequest);
        }
        catch (Exception ex)
        {
            this.logger.UnhandledErrorOccurred(exception: ex);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        finally
        {
            this.logger.MethodExecuted();
        }
    }

}

#pragma warning restore IDE0060
