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
using Beef.Entities;
using Karamem0.SampleApplication.Business.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Business
{
    /// <summary>
    /// Defines the <see cref="User"/> business functionality.
    /// </summary>
    public partial interface IUserManager
    {
        /// <summary>
        /// Gets the <see cref="UserCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="UserCollectionResult"/>.</returns>
        Task<UserCollectionResult> GetAllAsync();
    }
}

#pragma warning restore
#nullable restore
