/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Caching;
using Beef.Entities;
using Beef.Events;
using Karamem0.SampleApplication.Business.Data;
using Karamem0.SampleApplication.Business.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Business.DataSvc
{
    /// <summary>
    /// Provides the <see cref="ProductLog"/> data repository services.
    /// </summary>
    public partial class ProductLogDataSvc : IProductLogDataSvc
    {
        private readonly IProductLogData _data;
        private readonly IEventPublisher _evtPub;
        private readonly IRequestCache _cache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogDataSvc"/> class.
        /// </summary>
        /// <param name="data">The <see cref="IProductLogData"/>.</param>
        /// <param name="evtPub">The <see cref="IEventPublisher"/>.</param>
        /// <param name="cache">The <see cref="IRequestCache"/>.</param>
        public ProductLogDataSvc(IProductLogData data, IEventPublisher evtPub, IRequestCache cache)
            { _data = Check.NotNull(data, nameof(data)); _evtPub = Check.NotNull(evtPub, nameof(evtPub)); _cache = Check.NotNull(cache, nameof(cache)); ProductLogDataSvcCtor(); }

        partial void ProductLogDataSvcCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Creates a new <see cref="ProductLog"/>.
        /// </summary>
        /// <param name="value">The <see cref="ProductLog"/>.</param>
        /// <returns>The created <see cref="ProductLog"/>.</returns>
        public Task<ProductLog> CreateAsync(ProductLog value) => DataSvcInvoker.Current.InvokeAsync(this, async () =>
        {
            var __result = await _data.CreateAsync(Check.NotNull(value, nameof(value))).ConfigureAwait(false);
            await _evtPub.PublishValue(__result, $"SampleApplication.ProductLog.{_evtPub.FormatKey(__result)}", "Create").SendAsync().ConfigureAwait(false);
            return _cache.SetAndReturnValue(__result);
        });
    }
}

#pragma warning restore
#nullable restore