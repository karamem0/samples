/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using Beef.Validation;
using Microsoft.Extensions.DependencyInjection;
using Karamem0.SampleApplication.Business.Entities;
using Karamem0.SampleApplication.Business.Validation;

namespace Karamem0.SampleApplication.Business
{
    /// <summary>
    /// Provides the generated <b>Validator</b> Manager-layer services.
    /// </summary>
    public static class ServiceCollectionsValidationExtension
    {
        /// <summary>
        /// Adds the generated <b>Validator</b> Manager-layer services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddGeneratedValidationServices(this IServiceCollection services)
        {
            return services.AddScoped<IValidator<Product>, ProductValidator>();
        }
    }
}

#pragma warning restore
#nullable restore
