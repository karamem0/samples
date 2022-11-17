//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

namespace Karamem0.SampleApplication.Business;

/// <summary>
/// Provides the <see cref="IConfiguration"/> settings.
/// </summary>
public class SampleApplicationSettings : SettingsBase
{
    /// <summary>
    /// Gets the setting prefixes in order of precedence.
    /// </summary>
    public static string[] Prefixes { get; } = { "SampleApplication/", "Common/" };

    /// <summary>
    /// Initializes a new instance of the <see cref="SampleApplicationSettings"/> class.
    /// </summary>
    /// <param name="configuration">The <see cref="IConfiguration"/>.</param>
    public SampleApplicationSettings(IConfiguration configuration) : base(configuration, Prefixes) => ValidationArgs.DefaultUseJsonNames = true;

    /// <summary>
    /// Gets the database connection string.
    /// </summary>
    public string DatabaseConnectionString => GetValue<string>("ConnectionStrings__Database");
}
