//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

namespace Karamem0.SampleApplication.Business.Data;

/// <summary>
/// Represents the <b>Karamem0.SampleApplication</b> database.
/// </summary>
public class SampleApplicationDb : SqlServerDatabase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SampleApplicationDb"/> class.
    /// </summary>
    /// <param name="create">The factory to create the <see cref="SqlConnection"/>.</param>
    /// <param name="logger">The optional <see cref="ILogger"/>.</param>
    public SampleApplicationDb(Func<SqlConnection> create, ILogger<SampleApplicationDb>? logger = null) : base(create, logger) { }

    /// <inheritdoc/>
    protected override Task OnConnectionOpenAsync(DbConnection connection, CancellationToken cancellationToken) => SetSqlSessionContextAsync(cancellationToken: cancellationToken);
}
