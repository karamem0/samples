//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System.Text.Json.Serialization;

namespace Karamem0.SampleApplication.Models;

public record ResourceData
{

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("@odata.id")]
    public required string ODataId { get; set; }

    [JsonPropertyName("@odata.type")]
    public required string ODataType { get; set; }

}
