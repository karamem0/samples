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
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Karamem0.SampleApplication.Functions;

public class ReceiveSubscriptionFunction(ILogger<ReceiveSubscriptionFunction> logger, IBlobsService blobsService, IEncryptionService encryptionService)
{

    private readonly ILogger<ReceiveSubscriptionFunction> logger = logger;

    private readonly IBlobsService blobsService = blobsService;

    private readonly IEncryptionService encryptionService = encryptionService;

    [Function("ReceiveSubscription")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Admin, "POST")] HttpRequest httpRequest)
    {
        try
        {
            this.logger.MethodExecuting();
            // 検証トークンがクエリ文字列に含まれている場合はその値をそのまま返却する
            var validationToken = httpRequest.Query["validationToken"];
            if (validationToken.Count > 0)
            {
                return new ContentResult()
                {
                    Content = validationToken,
                    ContentType = "text/plain",
                    StatusCode = StatusCodes.Status200OK
                };
            }
            // 設定ファイルを取得する
            var settings = await this.blobsService.GetSettingsAsync();
            if (settings is null)
            {
                this.logger.SettingsFileNotFound();
            }
            else
            {
                var changeNotificationCollection = await httpRequest.ReadFromJsonAsync<ChangeNotificationCollection>();
                _ = changeNotificationCollection ?? throw new InvalidOperationException();
                foreach (var changeNotification in changeNotificationCollection.Value)
                {
                    // サブスクリプションの登録時に設定したクライアント状態と一致するか検証する
                    if (changeNotification.ClientState != settings.ClientState)
                    {
                        this.logger.ClientStateDoesNotMatch();
                        continue;
                    }
                    // 暗号化された対称鍵を復号化する
                    var symmetricKey = await this.encryptionService.DecryptSymmetricKeyAsync(changeNotification.EncryptedContent.DataKey);
                    // 署名を検証する
                    var validationResult = await this.encryptionService.ValidateSignatureAsync(
                        symmetricKey,
                        changeNotification.EncryptedContent.Data,
                        changeNotification.EncryptedContent.DataSignature
                    );
                    if (validationResult is not true)
                    {
                        this.logger.SignatureValidationFailed();
                        continue;
                    }
                    // リソースデータを復号化する
                    var resourceData = await this.encryptionService.DecryptResourceDataAsync(symmetricKey, changeNotification.EncryptedContent.Data);
                    this.logger.ChangeNotificationReceived(resourceData: resourceData);
                }
            }
            return new OkResult();
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
