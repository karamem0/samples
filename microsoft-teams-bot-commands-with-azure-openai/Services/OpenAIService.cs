//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.OpenAI;

namespace Karamem0.SampleApplication;

public class OpenAIService(OpenAIClient client, string deploymentName)
{

    private static readonly string CreateReservationPatameters = "{\"type\": \"object\",\"properties\": {\"command\": {\"type\": \"string\",\"description\":\"The value should be '予約作成'\"},\"location\": {\"type\": \"string\"}}}";

    private static readonly string UpdateReservationPatameters = "{\"type\": \"object\",\"properties\": {\"command\": {\"type\": \"string\",\"description\":\"The value should be '予約変更'\"},\"location\": {\"type\": \"string\"}}}";

    private static readonly string RemoveReservationPatameters = "{\"type\": \"object\",\"properties\": {\"command\": {\"type\": \"string\",\"description\":\"The value should be '予約削除'\"},\"location\": {\"type\": \"string\"}}}";

    private readonly OpenAIClient client = client;

    private readonly string deploymentName = deploymentName;

    public async Task<ReservationParameter?> GetReservationParameter(string text, CancellationToken cancellationToken = default)
    {
        var options = new ChatCompletionsOptions(
            this.deploymentName,
            [
                new ChatRequestUserMessage(text)
            ])
        {
            FunctionCall = FunctionDefinition.Auto
        };
        options.Functions.Add(new FunctionDefinition()
        {
            Name = "CreateReservation",
            Description = "予約を作成します。",
            Parameters = BinaryData.FromString(CreateReservationPatameters)
        });
        options.Functions.Add(new FunctionDefinition()
        {
            Name = "UpdateReservation",
            Description = "予約を変更します。",
            Parameters = BinaryData.FromString(UpdateReservationPatameters)
        });
        options.Functions.Add(new FunctionDefinition()
        {
            Name = "RemoveReservation",
            Description = "予約を削除します。",
            Parameters = BinaryData.FromString(RemoveReservationPatameters)
        });
        var response = await this.client.GetChatCompletionsAsync(options, cancellationToken);
        var arguments = response.Value.Choices[0]?.Message?.FunctionCall?.Arguments;
        return arguments is null ? null : JsonSerializer.Deserialize<ReservationParameter>(arguments);
    }

}
