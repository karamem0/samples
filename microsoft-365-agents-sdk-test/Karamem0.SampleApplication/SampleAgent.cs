//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Core.Models;

namespace Karamem0.SampleApplication;

public class SampleAgent(AgentApplicationOptions options) : AgentApplication(options)
{

    [Route(RouteType = RouteType.Activity, Type = ActivityTypes.ConversationUpdate, Rank = RouteRank.Last)]
    public async Task OnConversationUpdateAsync(
        ITurnContext turnContext,
        ITurnState turnState,
        CancellationToken cancellationToken = default
    )
    {
        foreach (var member in turnContext.Activity.MembersAdded)
        {
            if (member.Id != turnContext.Activity.Recipient.Id)
            {
                _ = await turnContext.SendActivityAsync("こんにちは！", cancellationToken: cancellationToken);
            }
        }
    }

}
