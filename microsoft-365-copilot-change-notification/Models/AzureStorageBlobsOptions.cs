//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

namespace Karamem0.SampleApplication.Models;

public record AzureStorageBlobsOptions
{

    public required Uri Endpoint { get; set; }

    public required string ContainerName { get; set; }

}
