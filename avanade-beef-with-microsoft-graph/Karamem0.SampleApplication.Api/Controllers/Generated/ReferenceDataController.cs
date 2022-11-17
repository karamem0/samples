/*
 * This file is automatically generated; any changes will be lost.
 */

#nullable enable
#pragma warning disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Beef;
using Beef.AspNetCore.WebApi;
using Beef.Entities;
using Beef.RefData;
using Karamem0.SampleApplication.Common.Entities;
using RefDataNamespace = Karamem0.SampleApplication.Business.Entities;

namespace Karamem0.SampleApplication.Api.Controllers
{
    /// <summary>
    /// Provides the <b>ReferenceData</b> Web API functionality.
    /// </summary>
    public partial class ReferenceDataController : ControllerBase
    {
        /// <summary>
        /// Gets the reference data entries for the specified entities and codes from the query string; e.g: ref?entity=codeX,codeY&amp;entity2=codeZ&amp;entity3
        /// </summary>
        /// <returns>A <see cref="ReferenceDataMultiCollection"/>.</returns>
        [HttpGet()]
        [Route("ref")]
        [ProducesResponseType(typeof(ReferenceDataMultiCollection), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetNamed()
        {
            return new WebApiGet<ReferenceDataMultiCollection>(this, async () =>
            {
                var coll = new ReferenceDataMultiCollection();
                var inactive = this.IncludeInactive();
                var refSelection = this.ReferenceDataSelection();

                var names = refSelection.Select(x => x.Key).ToArray();
                await RefDataNamespace.ReferenceData.Current.PrefetchAsync(names).ConfigureAwait(false);

                foreach (var q in refSelection)
                {
                    switch (q.Key)
                    {
                    }
                }

                return coll;
            }, operationType: OperationType.Read, statusCode: HttpStatusCode.OK, alternateStatusCode: HttpStatusCode.NoContent);
        }
    }
}

#pragma warning restore
#nullable restore
