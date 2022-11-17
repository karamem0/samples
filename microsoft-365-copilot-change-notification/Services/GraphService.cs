//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Graph;
using Microsoft.Graph.Models;

namespace Karamem0.SampleApplication.Services;

public interface IGraphService
{

    Task<Subscription> CreateSubscriptionAsync(
        string notificationUrl,
        string encryptionCertificateId,
        string clientState
    );

    Task UpdateSubscriptionAsync(string subscriptionId);

}

public class GraphService(GraphServiceClient graphServiceClient) : IGraphService
{

    private readonly GraphServiceClient graphServiceClient = graphServiceClient;

    public async Task<Subscription> CreateSubscriptionAsync(
        string notificationUrl,
        string encryptionCertificateId,
        string clientState
    )
    {
        var certificate = await File
            .ReadAllBytesAsync(Constants.CrtPemPath)
            .ConfigureAwait(false);
        var subscription = await this
            .graphServiceClient.Subscriptions.PostAsync(
                new Subscription()
                {
                    ChangeType = "created,deleted,updated",
                    NotificationUrl = notificationUrl,
                    Resource = "/copilot/interactionHistory/getAllEnterpriseInteractions",
                    IncludeResourceData = true,
                    EncryptionCertificate = Convert.ToBase64String(certificate),
                    EncryptionCertificateId = encryptionCertificateId,
                    ExpirationDateTime = DateTimeOffset.UtcNow.AddMinutes(15),
                    ClientState = clientState
                }
            )
            .ConfigureAwait(false);
        _ = subscription ?? throw new InvalidOperationException();
        return subscription;
    }

    public async Task UpdateSubscriptionAsync(string subscriptionId)
    {
        var subscription = new Subscription()
        {
            ExpirationDateTime = DateTimeOffset.UtcNow.AddMinutes(15)
        };
        _ = await this
            .graphServiceClient.Subscriptions[subscriptionId]
            .PatchAsync(subscription)
            .ConfigureAwait(false);
    }

}
