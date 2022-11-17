//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Azure.Storage.Blobs;
using Karamem0.SampleApplication.Models;

namespace Karamem0.SampleApplication.Services;

public interface IBlobsService
{

    Task<ChangeNotificationSettings?> GetSettingsAsync();

    Task SetSettingsAsync(ChangeNotificationSettings settings);

}

public class BlobsService(BlobContainerClient blobContainerClient) : IBlobsService
{

    private readonly BlobContainerClient blobContainerClient = blobContainerClient;

    public async Task<ChangeNotificationSettings?> GetSettingsAsync()
    {
        var blobClient = this.blobContainerClient.GetBlobClient("settings.json");
        var blobExists = await blobClient
            .ExistsAsync()
            .ConfigureAwait(false);
        if (blobExists.Value)
        {
            return await blobClient
                .DownloadContentAsync()
                .ContinueWith(task => task.Result.Value.Content.ToObjectFromJson<ChangeNotificationSettings>())
                .ConfigureAwait(false);
        }
        else
        {
            return null;
        }
    }

    public async Task SetSettingsAsync(ChangeNotificationSettings settings)
    {
        _ = await this
            .blobContainerClient.CreateIfNotExistsAsync()
            .ConfigureAwait(false);
        _ = await this
            .blobContainerClient.GetBlobClient("settings.json")
            .UploadAsync(BinaryData.FromObjectAsJson(settings), overwrite: true)
            .ConfigureAwait(false);
    }

}
