/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Data.Database;
using Beef.Entities;
using Beef.Mapper;
using Beef.Mapper.Converters;
using Karamem0.SampleApplication.Business.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Business.Data
{
    /// <summary>
    /// Provides the <see cref="ProductLog"/> data access.
    /// </summary>
    public partial class ProductLogData : IProductLogData
    {
        private readonly IDatabase _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogData"/> class.
        /// </summary>
        /// <param name="db">The <see cref="IDatabase"/>.</param>
        public ProductLogData(IDatabase db)
            { _db = Check.NotNull(db, nameof(db)); ProductLogDataCtor(); }

        partial void ProductLogDataCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Creates a new <see cref="ProductLog"/>.
        /// </summary>
        /// <param name="value">The <see cref="ProductLog"/>.</param>
        /// <returns>The created <see cref="ProductLog"/>.</returns>
        public Task<ProductLog> CreateAsync(ProductLog value) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = DbMapper.Default.CreateArgs("[SampleApplication].[spProductLogCreate]");
            return await _db.CreateAsync(__dataArgs, Check.NotNull(value, nameof(value))).ConfigureAwait(false);
        });

        /// <summary>
        /// Provides the <see cref="ProductLog"/> property and database column mapping.
        /// </summary>
        public partial class DbMapper : DatabaseMapper<ProductLog, DbMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DbMapper"/> class.
            /// </summary>
            public DbMapper()
            {
                Property(s => s.LogId).SetUniqueKey(false);
                Property(s => s.ProductId);
                Property(s => s.ProductName);
                Property(s => s.Price);
                AddStandardProperties(excludeETag: true);
                DbMapperCtor();
            }

            partial void DbMapperCtor(); // Enables the DbMapper constructor to be extended.
        }
    }
}

#pragma warning restore
#nullable restore
