/*
 * This file is automatically generated; any changes will be lost. 
 */

#nullable enable
#pragma warning disable

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Provides the generated <b>DataSvc</b>-layer services.
    /// </summary>
    public static partial class ServiceCollectionsExtension
    {
        /// <summary>
        /// Adds the generated <b>DataSvc</b>-layer services.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddGeneratedDataSvcServices(this IServiceCollection services)
        {
            return services.AddScoped<IProductDataSvc, ProductDataSvc>();
        }
    }
}

#pragma warning restore
#nullable restore