//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Agents.Builder.Dialogs;
using Microsoft.Agents.Builder.Dialogs.Prompts;
using Microsoft.Agents.Core.Models;

namespace Karamem0.SampleApplication;

public class SampleDialog() : ComponentDialog(nameof(SampleDialog))
{

    protected override async Task OnInitializeAsync(DialogContext dialogContext)
    {
        _ = this.AddDialog(
            new WaterfallDialog(
                nameof(WaterfallDialog),
                [
                    this.OnBeforeAsync,
                    this.OnAfterAsync
                ]
            )
        );
        _ = this.AddDialog(new TextPrompt(nameof(TextPrompt)));
    }

    private async Task<DialogTurnResult> OnBeforeAsync(
        WaterfallStepContext stepContext,
        CancellationToken cancellationToken = default
    )
    {
        return await stepContext.PromptAsync(
            nameof(TextPrompt),
            new PromptOptions
            {
                Prompt = MessageFactory.Text("お名前を教えてください。")
            },
            cancellationToken
        );
    }

    private async Task<DialogTurnResult> OnAfterAsync(
        WaterfallStepContext stepContext,
        CancellationToken cancellationToken = default
    )
    {
        _ = await stepContext.Context.SendActivityAsync(
            $"こんにちは、{stepContext.Result}さん！",
            cancellationToken: cancellationToken
        );
        return await stepContext.EndDialogAsync(cancellationToken: cancellationToken);
    }

}
