//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Karamem0.SampleApplication.Logging;

public static class LoggerExtensions
{

    private static readonly Action<ILogger, string?, Exception?> methodExecuting = LoggerMessage.Define<string?>(
        LogLevel.Information,
        new EventId(2001),
        "[{MethodName}] メソッドを実行しています。"
    );

    public static void MethodExecuting(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        Exception? exception = null
    )
    {
        methodExecuting.Invoke(
            logger,
            methodName,
            exception
        );
    }

    private static readonly Action<ILogger, string?, Exception?> methodExecuted = LoggerMessage.Define<string?>(
        LogLevel.Information,
        new EventId(2002),
        "[{MethodName}] メソッドを実行しました。"
    );

    public static void MethodExecuted(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        Exception? exception = null
    )
    {
        methodExecuted.Invoke(
            logger,
            methodName,
            exception
        );
    }

    private static readonly Action<ILogger, string?, string?, Exception?> changeNotificationReceived = LoggerMessage.Define<string?, string?>(
        LogLevel.Information,
        new EventId(2003),
        "[{MethodName}] 変更通知を受信しました。{ResourceData}"
    );

    public static void ChangeNotificationReceived(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        BinaryData? resourceData = null,
        Exception? exception = null
    )
    {
        changeNotificationReceived.Invoke(
            logger,
            methodName,
            resourceData?.ToString(),
            exception
        );
    }

    private static readonly Action<ILogger, string?, Exception?> settingsFileNotFound = LoggerMessage.Define<string?>(
        LogLevel.Warning,
        new EventId(3001),
        "[{MethodName}] 設定ファイルが存在しません。"
    );

    public static void SettingsFileNotFound(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        Exception? exception = null
    )
    {
        settingsFileNotFound.Invoke(
            logger,
            methodName,
            exception
        );
    }

    private static readonly Action<ILogger, string?, Exception?> clientStateDoesNotMatch = LoggerMessage.Define<string?>(
        LogLevel.Warning,
        new EventId(3002),
        "[{MethodName}] クライアントの状態が一致しません。"
    );

    public static void ClientStateDoesNotMatch(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        Exception? exception = null
    )
    {
        clientStateDoesNotMatch.Invoke(
            logger,
            methodName,
            exception
        );
    }

    private static readonly Action<ILogger, string?, Exception?> signatureValidationFailed = LoggerMessage.Define<string?>(
        LogLevel.Warning,
        new EventId(3003),
        "[{MethodName}] 署名の検証に失敗しました。"
    );

    public static void SignatureValidationFailed(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        Exception? exception = null
    )
    {
        signatureValidationFailed.Invoke(
            logger,
            methodName,
            exception
        );
    }

    private static readonly Action<ILogger, string?, Exception?> methodFailed = LoggerMessage.Define<string?>(
        LogLevel.Error,
        new EventId(4001),
        "[{MethodName}] メソッドの実行に失敗しました。"
    );

    public static void MethodFailed(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        Exception? exception = null
    )
    {
        methodFailed.Invoke(
            logger,
            methodName,
            exception
        );
    }

    private static readonly Action<ILogger, string?, Exception?> unhandledErrorOccurred = LoggerMessage.Define<string?>(
        LogLevel.Critical,
        new EventId(5001),
        "[{MethodName}] 予期しない問題が発生しました。"
    );

    public static void UnhandledErrorOccurred(
        this ILogger logger,
        [CallerMemberName()] string? methodName = null,
        Exception? exception = null
    )
    {
        unhandledErrorOccurred.Invoke(
            logger,
            methodName,
            exception
        );
    }

}
