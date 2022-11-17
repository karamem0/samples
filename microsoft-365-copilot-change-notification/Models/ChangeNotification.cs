//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System.Text.Json.Serialization;

namespace Karamem0.SampleApplication.Models;

public record ChangeNotification
{

    [JsonPropertyName("clientState")]
    public required string ClientState { get; set; }

    [JsonPropertyName("changeType")]
    public required string ChangeType { get; set; }

    [JsonPropertyName("encryptedContent")]
    public required ChangeNotificationEncryptedContent EncryptedContent { get; set; }

    [JsonPropertyName("resource")]
    public required string Resource { get; set; }

    [JsonPropertyName("resourceData")]
    public required ResourceData ResourceData { get; set; }

    [JsonPropertyName("subscriptionId")]
    public required string SubscriptionId { get; set; }

}
