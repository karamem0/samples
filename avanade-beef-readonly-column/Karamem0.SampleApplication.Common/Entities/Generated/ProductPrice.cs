/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Beef.Entities;
using Newtonsoft.Json;

namespace Karamem0.SampleApplication.Common.Entities
{
    /// <summary>
    /// Represents the Product Price entity.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public partial class ProductPrice : IUniqueKey
    {
        /// <summary>
        /// Gets or sets the Product Id.
        /// </summary>
        [JsonProperty("productId", DefaultValueHandling = DefaultValueHandling.Include)]
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the Price.
        /// </summary>
        [JsonProperty("price", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the list of property names that represent the unique key.
        /// </summary>
        public string[] UniqueKeyProperties => new string[] { nameof(ProductId) };

        /// <summary>
        /// Creates the <see cref="UniqueKey"/>.
        /// </summary>
        /// <returns>The <see cref="Beef.Entities.UniqueKey"/>.</returns>
        /// <param name="productId">The <see cref="ProductId"/>.</param>
        public static UniqueKey CreateUniqueKey(Guid productId) => new UniqueKey(productId);

        /// <summary>
        /// Gets the <see cref="UniqueKey"/> (consists of the following property(s): <see cref="ProductId"/>).
        /// </summary>
        public UniqueKey UniqueKey => CreateUniqueKey(ProductId);
    }
}

#pragma warning restore
#nullable restore
