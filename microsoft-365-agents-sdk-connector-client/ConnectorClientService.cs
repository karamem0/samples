//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Agents.Builder;
using Microsoft.Agents.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace Karamem0.SampleApplication;

public class ConnectorClientService(
    IHostApplicationLifetime hostApplicationLifetime,
    IConfiguration configuration,
    IChannelServiceClientFactory channelServiceClientFactory
) : BackgroundService
{

    private readonly IHostApplicationLifetime hostApplicationLifetime = hostApplicationLifetime;

    private readonly IConfiguration configuration = configuration;

    private readonly IChannelServiceClientFactory channelServiceClientFactory = channelServiceClientFactory;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var tenantId = this.configuration.GetValue<string>("Connections:ServiceConnection:Settings:TenantId")!;
        var clientId = this.configuration.GetValue<string>("Connections:ServiceConnection:Settings:ClientId")!;
        var claimsIdentity = new ClaimsIdentity([
            new Claim("ver", "1.0"),
            new Claim("appid", clientId)
        ]);
        var connectorClient = await this.channelServiceClientFactory.CreateConnectorClientAsync(
            claimsIdentity,
            $"https://smba.trafficmanager.net/jp/{tenantId}",
            "https://api.botframework.com/",
            cancellationToken
        );
        var activity = this.configuration.GetSection("Activity").Get<Activity>();
        _ = await connectorClient.Conversations.SendToConversationAsync(activity, cancellationToken);
        this.hostApplicationLifetime.StopApplication();
    }

}
