//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Agents.Authentication;
using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.App.Proactive;
using Microsoft.Agents.Core.Models;
using Microsoft.Extensions.Hosting;

namespace Karamem0.SampleApplication;

public class ProactiveService(
    IHostApplicationLifetime lifetime,
    IAgent agent,
    IConnections connections
) : BackgroundService
{

    private readonly IHostApplicationLifetime lifetime = lifetime;

    private readonly AgentApplication agent = (AgentApplication)agent;

    private readonly IConnections connections = connections;

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var conversationReference = new ConversationReference()
        {
            Agent = new ChannelAccount()
            {
                Id = "{{agent-id}}",
                Name = "{{agent-name}}"
            },
            User = new ChannelAccount()
            {
                Id = "{{user-id}}"
            },
            Conversation = new ConversationAccount()
            {
                Id = "{{conversation-id}}"
            },
            ChannelId = "webchat",
            ServiceUrl = "https://webchat.botframework.com/"
        };
        var connection = this.connections.GetDefaultConnection();
        var conversation = new Conversation(AgentClaims.CreateIdentity(connection.ConnectionSettings.ClientId), conversationReference);
        _ = await this.agent.Proactive.SendActivityAsync(
            conversation,
            new Activity()
            {
                Type = ActivityTypes.Message,
                Text = "Hello, world!"
            },
            cancellationToken
        );
        this.lifetime.StopApplication();
    }

}
