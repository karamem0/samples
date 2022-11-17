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
using CoreEx.Configuration;
using CoreEx.Entities;
using CoreEx.Http;
using CoreEx.Json;
using CoreEx.RefData;
using Microsoft.Extensions.Logging;
using Karamem0.SampleApplication.Common.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Common.Entities;

namespace Karamem0.SampleApplication.Common.Agents
{
    /// <summary>
    /// Defines the <b>ReferenceData</b> HTTP agent.
    /// </summary>
    public partial interface IReferenceDataAgent
    {
        /// <summary>
        /// Gets the reference data entries for the specified entities and codes from the query string; e.g: ref?entity=codeX,codeY&amp;entity2=codeZ&amp;entity3
        /// </summary>
        /// <param name="names">The optional list of reference data names.</param>
        /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="HttpResult"/>.</returns>
        /// <remarks>The reference data objects will need to be manually extracted from the corresponding response content.</remarks>
        Task<HttpResult> GetNamedAsync(string[] names, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// Provides the <b>ReferenceData</b> HTTP agent.
    /// </summary>
    public partial class ReferenceDataAgent : TypedHttpClientBase<ReferenceDataAgent>, IReferenceDataAgent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataAgent"/> class.
        /// </summary>
        /// <param name="client">The underlying <see cref="HttpClient"/>.</param>
        /// <param name="jsonSerializer">The <see cref="IJsonSerializer"/>.</param>
        /// <param name="executionContext">The <see cref="CoreEx.ExecutionContext"/>.</param>
        /// <param name="settings">The <see cref="SettingsBase"/>.</param>
        /// <param name="logger">The <see cref="ILogger"/>.</param>
        public ReferenceDataAgent(HttpClient client, IJsonSerializer jsonSerializer, CoreEx.ExecutionContext executionContext, SettingsBase settings, ILogger<ReferenceDataAgent> logger) 
            : base(client, jsonSerializer, executionContext, settings, logger) { }

        /// <summary>
        /// Gets the reference data entries for the specified entities and codes from the query string; e.g: ref?entity=codeX,codeY&amp;entity2=codeZ&amp;entity3
        /// </summary>
        /// <param name="names">The optional list of reference data names.</param>
        /// <param name="requestOptions">The optional <see cref="HttpRequestOptions"/>.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="HttpResult"/>.</returns>
        /// <remarks>The reference data objects will need to be manually extracted from the corresponding response content.</remarks>
        public Task<HttpResult> GetNamedAsync(string[] names, HttpRequestOptions? requestOptions = null, CancellationToken cancellationToken = default)
        {
            var ro = requestOptions ?? new HttpRequestOptions();
            if (names != null)
                ro.UrlQueryString += string.Join("&", names);
                
            return GetAsync("ref", ro, null, cancellationToken);
        }
    }
}

#pragma warning restore
#nullable restore