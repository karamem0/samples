//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

#pragma warning disable IDE0060

using Karamem0.SampleApplication.Logging;
using Karamem0.SampleApplication.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Karamem0.SampleApplication.Functions;

public class UpdateSubscriptionFunction(
    ILogger<UpdateSubscriptionFunction> logger,
    IGraphService graphService,
    IBlobsService blobsService
)
{

    private readonly ILogger<UpdateSubscriptionFunction> logger = logger;

    private readonly IGraphService graphService = graphService;

    private readonly IBlobsService blobsService = blobsService;

    [Function("UpdateSubscription")]
    public async Task RunAsync([TimerTrigger("0 */10 * * * *")] TimerInfo timerInfo)
    {
        try
        {
            this.logger.MethodExecuting();
            // 設定ファイルを取得する
            var settings = await this.blobsService.GetSettingsAsync();
            if (settings is null)
            {
                this.logger.SettingsFileNotFound();
            }
            else
            {
                // サブスクリプションの有効期限を延長する
                await this.graphService.UpdateSubscriptionAsync(settings.SubscriptionId);
            }
        }
        catch (InvalidOperationException ex)
        {
            this.logger.MethodFailed(exception: ex);
        }
        catch (Exception ex)
        {
            this.logger.UnhandledErrorOccurred(exception: ex);
        }
        finally
        {
            this.logger.MethodExecuted();
        }
    }

}

#pragma warning restore IDE0060
