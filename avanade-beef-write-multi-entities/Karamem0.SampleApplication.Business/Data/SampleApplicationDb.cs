//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Beef.Data.Database;
using System.Data.Common;

namespace Karamem0.SampleApplication.Business.Data
{
    /// <summary>
    /// Represents the <b>Karamem0.SampleApplication</b> database.
    /// </summary>
    public class SampleApplicationDb : DatabaseBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleApplicationDb"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="provider">The optional data provider.</param>
        public SampleApplicationDb(string connectionString, DbProviderFactory? provider = null) : base(connectionString, provider, new SqlRetryDatabaseInvoker()) { }

        /// <summary>
        /// Set the SQL Session Context when the connection is opened.
        /// </summary>
        /// <param name="dbConnection">The <see cref="DbConnection"/>.</param>
        public override void OnConnectionOpen(DbConnection dbConnection) => SetSqlSessionContext(dbConnection);
    }
}
