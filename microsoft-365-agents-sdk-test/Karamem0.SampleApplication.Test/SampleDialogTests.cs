//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.Compat;
using Microsoft.Agents.Builder.Dialogs;
using Microsoft.Agents.Builder.State;
using Microsoft.Agents.Builder.Testing;
using Microsoft.Agents.Storage;
using Microsoft.Agents.Storage.Transcript;
using NUnit.Framework;

namespace Karamem0.SampleApplication.Test;

public class SampleDialogTests
{

    [Test()]
    public async Task SampleDialogTest()
    {
        var conversationState = new ConversationState(new MemoryStorage());
        var testAdapter = TestAdapter.Create()
            .Use(new AutoSaveStateMiddleware(conversationState))
            .Use(new TranscriptLoggerMiddleware(new TraceTranscriptLogger(false)));
        var testFlow = new TestFlow(
            testAdapter,
            async (turnContext, cancellationToken) =>
            {
                await conversationState.LoadAsync(turnContext, false, cancellationToken);
                var dialogState = conversationState.GetValue(nameof(DialogState), () => new DialogState());
                var dialogSet = new DialogSet(dialogState);
                _ = dialogSet.Add(new SampleDialog());
                var dialogContext = await dialogSet.CreateContextAsync(turnContext, cancellationToken);
                var result = await dialogContext.ContinueDialogAsync(cancellationToken);
                if (result.Status == DialogTurnStatus.Empty)
                {
                    _ = await dialogContext.BeginDialogAsync(nameof(SampleDialog), null, cancellationToken);
                }
            }
        );
        await testFlow
            .SendConversationUpdate()
            .AssertReply("お名前を教えてください。")
            .Send("太郎")
            .AssertReply("こんにちは、太郎さん！")
            .StartTestAsync();
    }

}
