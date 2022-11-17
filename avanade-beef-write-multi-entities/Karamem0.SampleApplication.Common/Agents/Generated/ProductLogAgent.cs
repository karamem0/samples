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
    /// Defines the <see cref="ProductLog"/> Web API agent.
    /// </summary>
    public partial interface IProductLogAgent
    {
    }

    /// <summary>
    /// Provides the <see cref="ProductLog"/> Web API agent.
    /// </summary>
    public partial class ProductLogAgent : WebApiAgentBase, IProductLogAgent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductLogAgent"/> class.
        /// </summary>
        /// <param name="args">The <see cref="ISampleApplicationWebApiAgentArgs"/>.</param>
        public ProductLogAgent(ISampleApplicationWebApiAgentArgs args) : base(args) { }
    }
}

#pragma warning restore
#nullable restore