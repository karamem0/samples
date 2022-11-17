//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System.Text.Json.Serialization;

namespace Karamem0.SampleApplication.Models;

public record ChangeNotificationCollection
{

    [JsonPropertyName("validationTokens")]
    public required string[] ValidationTokens { get; set; }

    [JsonPropertyName("value")]
    public required ChangeNotification[] Value { get; set; }

}
