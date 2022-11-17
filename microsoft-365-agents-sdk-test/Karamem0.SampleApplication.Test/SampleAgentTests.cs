//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Agents.Builder;
using Microsoft.Agents.Builder.App;
using Microsoft.Agents.Builder.Testing;
using Microsoft.Agents.Storage;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Karamem0.SampleApplication.Test;

public class SampleAgentTests
{

    [Test()]
    public async Task SampleAgentTest()
    {
        var testHost = AgentTestHost.Create(builder =>
            {
                _ = builder.Services.AddSingleton<IStorage, MemoryStorage>();
                _ = builder.Services.AddTransient<IAgent>(provider => new SampleAgent(
                        new AgentApplicationOptions(provider.GetRequiredService<IStorage>())
                    )
                );
            }
        );
        var testFlow = testHost.CreateTestFlow();
        await testFlow
            .SendConversationUpdate()
            .AssertReply("こんにちは！")
            .StartTestAsync();
    }

}
