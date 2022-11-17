//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System.Text.Json.Serialization;

namespace Karamem0.SampleApplication.Models;

public record ChangeNotificationSettings
{

    [JsonPropertyName("clientState")]
    public required string ClientState { get; set; }

    [JsonPropertyName("encryptionCertificateId")]
    public required string EncryptionCertificateId { get; set; }

    [JsonPropertyName("subscriptionId")]
    public required string SubscriptionId { get; set; }

}
