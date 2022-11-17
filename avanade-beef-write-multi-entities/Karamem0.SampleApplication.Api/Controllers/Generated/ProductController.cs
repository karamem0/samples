/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Karamem0.SampleApplication.Business;
using Karamem0.SampleApplication.Business.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Api.Controllers
{
    /// <summary>
    /// Provides the <see cref="Product"/> Web API functionality.
    /// </summary>
    [Route("products")]
    public partial class ProductController : ControllerBase
    {
        private readonly IProductManager _manager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductController"/> class.
        /// </summary>
        /// <param name="manager">The <see cref="IProductManager"/>.</param>
        public ProductController(IProductManager manager)
            { _manager = Check.NotNull(manager, nameof(manager)); ProductControllerCtor(); }

        partial void ProductControllerCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the <see cref="ProductCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="ProductCollection"/></returns>
        [HttpGet("")]
        [ProducesResponseType(typeof(ProductCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetAll() =>
            new WebApiGet<ProductCollectionResult, ProductCollection, Product>(this, () => _manager.GetAllAsync(),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);

        /// <summary>
        /// Gets the specified <see cref="Product"/>.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        /// <returns>The selected <see cref="Product"/> where found.</returns>
        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult Get(Guid productId) =>
            new WebApiGet<Product?>(this, () => _manager.GetAsync(productId),
                operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NotFound);

        /// <summary>
        /// Deletes the specified <see cref="Product"/>.
        /// </summary>
        /// <param name="productId">The Product Id.</param>
        [HttpDelete("{productId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult Delete(Guid productId) =>
            new WebApiDelete(this, () => _manager.DeleteAsync(productId),
                operationType: OperationType.Delete, statusCode: HttpStatusCode.NoContent);

        /// <summary>
        /// Creates a new <see cref="Product"/>.
        /// </summary>
        /// <param name="value">The <see cref="Product"/>.</param>
        /// <returns>The created <see cref="Product"/>.</returns>
        [HttpPost("")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        public IActionResult Create([FromBody] Product value) =>
            new WebApiPost<Product>(this, () => _manager.CreateAsync(WebApiActionBase.Value(value)),
                operationType: OperationType.Create, statusCode: HttpStatusCode.Created, alternateStatusCode: null, locationUri: (r) => new Uri($"/products/{r.ProductId}", UriKind.Relative));

        /// <summary>
        /// Updates an existing <see cref="Product"/>.
        /// </summary>
        /// <param name="value">The <see cref="Product"/>.</param>
        /// <param name="productId">The Product Id.</param>
        /// <returns>The updated <see cref="Product"/>.</returns>
        [HttpPut("{productId}")]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public IActionResult Update([FromBody] Product value, Guid productId) =>
            new WebApiPut<Product>(this, () => _manager.UpdateAsync(WebApiActionBase.Value(value), productId),
                operationType: OperationType.Update, statusCode: HttpStatusCode.OK, alternateStatusCode: null);
    }
}

#pragma warning restore
#nullable restore