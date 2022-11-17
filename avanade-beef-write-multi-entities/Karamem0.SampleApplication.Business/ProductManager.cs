using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beef;
using Beef.Business;
using Beef.Entities;
using Beef.Validation;
using Karamem0.SampleApplication.Business.Entities;
using Karamem0.SampleApplication.Business.DataSvc;
using Karamem0.SampleApplication.Business.Validation;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Business
{
    /// <summary>
    /// Provides the <see cref="Product"/> business functionality.
    /// </summary>
    public partial class ProductManager : IProductManager
    {
        /// <summary>
        /// Creates a new <see cref="Product"/>.
        /// </summary>
        /// <param name="value">The <see cref="Product"/>.</param>
        /// <returns>The created <see cref="Product"/>.</returns>
        public async Task<Product> CreateOnImplementationAsync(Product value)
        {
            var result = await _dataService.CreateAsync(value).ConfigureAwait(false);
            await _logDataService.CreateAsync(new ProductLog()
            {
                LogId = await _guidIdentifierGenerator.GenerateIdentifierAsync(),
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                Price = value.Price,
            }).ConfigureAwait(false);
            return result;
        }

        /// <summary>
        /// Updates an existing <see cref="Product"/>.
        /// </summary>
        /// <param name="value">The <see cref="Product"/>.</param>
        /// <param name="productId">The Product Id.</param>
        /// <returns>The updated <see cref="Product"/>.</returns>
        public async Task<Product> UpdateOnImplementationAsync(Product value, Guid productId)
        {
            var result = await _dataService.UpdateAsync(value).ConfigureAwait(false);
            await _logDataService.CreateAsync(new ProductLog()
            {
                LogId = await _guidIdentifierGenerator.GenerateIdentifierAsync(),
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                Price = value.Price,
            }).ConfigureAwait(false);
            return result;
        }
    }
}
