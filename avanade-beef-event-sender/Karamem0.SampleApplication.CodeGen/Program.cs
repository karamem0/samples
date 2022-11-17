//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

namespace Karamem0.SampleApplication.CodeGen;

/// <summary>
/// Represents the <b>code generation</b> program (capability).
/// </summary>
public static class Program
{
    /// <summary>
    /// Main startup.
    /// </summary>
    /// <param name="args">The startup arguments.</param>
    /// <returns>The status code whereby zero indicates success.</returns>
    public static Task<int> Main(string[] args) => Beef.CodeGen.CodeGenConsole.Create("Karamem0", "SampleApplication").Supports(entity: true, refData: true).RunAsync(args);
}
