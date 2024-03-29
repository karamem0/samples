/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Beef.Entities;
using Beef.WebApi;
using Newtonsoft.Json.Linq;
using Karamem0.SampleApplication.Common.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Common.Entities;

namespace Karamem0.SampleApplication.Common.Agents
{
    /// <summary>
    /// Defines the <see cref="User"/> Web API agent.
    /// </summary>
    public partial interface IUserAgent
    {
        /// <summary>
        /// Gets the <see cref="UserCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        Task<WebApiAgentResult<UserCollectionResult>> GetAllAsync(WebApiRequestOptions? requestOptions = null);
    }

    /// <summary>
    /// Provides the <see cref="User"/> Web API agent.
    /// </summary>
    public partial class UserAgent : WebApiAgentBase, IUserAgent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAgent"/> class.
        /// </summary>
        /// <param name="args">The <see cref="ISampleApplicationWebApiAgentArgs"/>.</param>
        public UserAgent(ISampleApplicationWebApiAgentArgs args) : base(args) { }

        /// <summary>
        /// Gets the <see cref="UserCollectionResult"/> that contains the items that match the selection criteria.
        /// </summary>
        /// <param name="requestOptions">The optional <see cref="WebApiRequestOptions"/>.</param>
        /// <returns>A <see cref="WebApiAgentResult"/>.</returns>
        public Task<WebApiAgentResult<UserCollectionResult>> GetAllAsync(WebApiRequestOptions? requestOptions = null) =>
            GetCollectionResultAsync<UserCollectionResult, UserCollection, User>("users", requestOptions: requestOptions,
                args: Array.Empty<WebApiArg>());
    }
}

#pragma warning restore
#nullable restore
