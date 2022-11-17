//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System.Text.Json.Serialization;

namespace Karamem0.SampleApplication.Models;

public record ChangeNotificationEncryptedContent
{

    [JsonPropertyName("data")]
    public required BinaryData Data { get; set; }

    [JsonPropertyName("dataKey")]
    public required BinaryData DataKey { get; set; }

    [JsonPropertyName("dataSignature")]
    public required BinaryData DataSignature { get; set; }

    [JsonPropertyName("encryptionCertificateId")]
    public required string EncryptionCertificateId { get; set; }

    [JsonPropertyName("encryptionCertificateThumbprint")]
    public required string EncryptionCertificateThumbprint { get; set; }

}
