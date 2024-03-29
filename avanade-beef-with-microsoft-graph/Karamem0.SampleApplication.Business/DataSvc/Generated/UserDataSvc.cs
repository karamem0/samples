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
using Beef.Entities;
using Karamem0.SampleApplication.Business.Data;
using Karamem0.SampleApplication.Business.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Business.DataSvc
{
    /// <summary>
    /// Provides the <see cref="User"/> data repository services.
    /// </summary>
    public partial class UserDataSvc : IUserDataSvc
    {
        private readonly IUserData _data;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDataSvc"/> class.
        /// </summary>
        /// <param name="data">The <see cref="IUserData"/>.</param>
        public UserDataSvc(IUserData data)
        { _data = Check.NotNull(data, nameof(data)); UserDataSvcCtor(); }

        partial void UserDataSvcCtor(); // Enables additional functionality to be added to the constructor.

        /// <summary>
        /// Gets the <see cref="UserCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="UserCollectionResult"/>.</returns>
        public Task<UserCollectionResult> GetAllAsync() => DataSvcInvoker.Current.InvokeAsync(this, async () =>
        {
            var __result = await _data.GetAllAsync().ConfigureAwait(false);
            return __result;
        });
    }
}

#pragma warning restore
#nullable restore
