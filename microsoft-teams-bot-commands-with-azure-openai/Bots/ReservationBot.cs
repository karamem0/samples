//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Teams;
using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication;

public class ReservationBot(OpenAIService openAIService) : TeamsActivityHandler
{

    private readonly OpenAIService openAIService = openAIService;

    protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
    {
        var command = turnContext.Activity.RemoveRecipientMention();
        // var message = command switch
        // {
        //     "予約作成" => "予約を作成しました。",
        //     "予約変更" => "予約を変更しました。",
        //     "予約削除" => "予約を削除しました。",
        //     _ => "認識できないコマンドです。"
        // };
        var parameter = await this.openAIService.GetReservationParameter(command, cancellationToken: cancellationToken);
        var message = parameter?.Command switch
        {
            "予約作成" => $"{parameter?.Location ?? "<不明な場所>"}の予約を作成しました。",
            "予約変更" => $"{parameter?.Location ?? "<不明な場所>"}の予約を変更しました。",
            "予約削除" => $"{parameter?.Location ?? "<不明な場所>"}の予約を削除しました。",
            _ => "認識できないコマンドです。"
        };
        await turnContext.SendActivityAsync(MessageFactory.Text(message, message), cancellationToken);
    }

    protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
    {
        var welcomeText = "Hello and welcome!";
        foreach (var member in membersAdded)
        {
            if (member.Id != turnContext.Activity.Recipient.Id)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
            }
        }
    }

}
