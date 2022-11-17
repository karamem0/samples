//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karamem0.SampleApplication.Business.Entities;
using Microsoft.Graph;

namespace Karamem0.SampleApplication.Business.Data
{
    /// <summary>
    /// Provides the <see cref="User"/> data access.
    /// </summary>
    public partial class UserData : IUserData
    {
        private readonly GraphServiceClient _graphServiceClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData"/> class.
        /// </summary>
        public UserData(GraphServiceClient graphServiceClient) : this()
        {
            _graphServiceClient = graphServiceClient;
        }

        /// <summary>
        /// Gets the <see cref="UserCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <returns>The <see cref="UserCollectionResult"/>.</returns>
        public async Task<UserCollectionResult> GetAllOnImplementationAsync()
        {
            var __result = await _graphServiceClient.Users.Request().GetAsync();
            return new UserCollectionResult(__result.Select(_ => new Entities.User()
            {
                Id = new Guid(_.Id),
                UserPrincipalName = _.UserPrincipalName,
                DisplayName = _.DisplayName,
            }));
        }
    }
}
