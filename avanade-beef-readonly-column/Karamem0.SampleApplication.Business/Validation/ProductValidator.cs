//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Beef.Validation;
using Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Business.Validation
{
    /// <summary>
    /// Represents a <see cref="ProductValidator"/> validator.
    /// </summary>
    public class ProductValidator : Validator<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductValidator"/> class.
        /// </summary>
        public ProductValidator()
        {
            Property(x => x.ProductName).String(255).Mandatory();
            Property(x => x.Price).Numeric(false).Mandatory();
        }
    }
}
