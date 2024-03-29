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
    /// Provides the <see cref="Product"/> data access.
    /// </summary>
    public partial class ProductData : IProductData
    {
        private readonly IDatabase _db;

        private Action<DatabaseParameters, IDatabaseArgs>? _getAllOnQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductData"/> class.
        /// </summary>
        /// <param name="db">The <see cref="IDatabase"/>.</param>
        public ProductData(IDatabase db)
            { _db = Check.NotNull(db, nameof(db)); ProductDataCtor(); }

        partial void ProductDataCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the <see cref="ProductCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="ProductCollectionResult"/>.</returns>
        public Task<ProductCollectionResult> GetAllAsync() => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            ProductCollectionResult __result = new ProductCollectionResult();
            var __dataArgs = DbMapper.Default.CreateArgs("[SampleApplication].[spProductGetAll]");
            __result.Result = await _db.Query(__dataArgs, p => _getAllOnQuery?.Invoke(p, __dataArgs)).SelectQueryAsync<ProductCollection>().ConfigureAwait(false);
            return await Task.FromResult(__result).ConfigureAwait(false);
        });

        /// <summary>
        /// Gets the specified <see cref="Product"/>.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        /// <returns>The selected <see cref="Product"/> where found.</returns>
        public Task<Product?> GetAsync(Guid productId) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = DbMapper.Default.CreateArgs("[SampleApplication].[spProductGet]");
            return await _db.GetAsync(__dataArgs, productId).ConfigureAwait(false);
        });

        /// <summary>
        /// Deletes the specified <see cref="Product"/>.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        public Task DeleteAsync(Guid productId) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = DbMapper.Default.CreateArgs("[SampleApplication].[spProductDelete]");
            await _db.DeleteAsync(__dataArgs, productId).ConfigureAwait(false);
        });

        /// <summary>
        /// Creates a new <see cref="Product"/>.
        /// </summary>
        /// <param name="value">The <see cref="Product"/>.</param>
        /// <returns>The created <see cref="Product"/>.</returns>
        public Task<Product> CreateAsync(Product value) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = DbMapper.Default.CreateArgs("[SampleApplication].[spProductCreate]");
            return await _db.CreateAsync(__dataArgs, Check.NotNull(value, nameof(value))).ConfigureAwait(false);
        });

        /// <summary>
        /// Updates an existing <see cref="Product"/>.
        /// </summary>
        /// <param name="value">The <see cref="Product"/>.</param>
        /// <returns>The updated <see cref="Product"/>.</returns>
        public Task<Product> UpdateAsync(Product value) => DataInvoker.Current.InvokeAsync(this, async () =>
        {
            var __dataArgs = DbMapper.Default.CreateArgs("[SampleApplication].[spProductUpdate]");
            return await _db.UpdateAsync(__dataArgs, Check.NotNull(value, nameof(value))).ConfigureAwait(false);
        });

        /// <summary>
        /// Provides the <see cref="Product"/> property and database column mapping.
        /// </summary>
        public partial class DbMapper : DatabaseMapper<Product, DbMapper>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DbMapper"/> class.
            /// </summary>
            public DbMapper()
            {
                Property(s => s.ProductId).SetUniqueKey(false);
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
