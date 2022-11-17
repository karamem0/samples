//
// Copyright (c) 2011-2026 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/samples/blob/main/LICENSE
//

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karamem0.SampleApplication.Models
{

    [JsonObject()]
    public class SubscribeInformation
    {

        [JsonProperty("changeType")]
        public string ChangeType { get; private set; }

        [JsonProperty("clientState")]
        public object ClientState { get; private set; }

        [JsonProperty("resource")]
        public string Resource { get; private set; }

        [JsonProperty("resourceData")]
        public SubscribeResourceData ResourceData { get; private set; }

        [JsonProperty("subscriptionExpirationDateTime")]
        public DateTime SubscriptionExpirationDateTime { get; private set; }

        [JsonProperty("subscriptionId")]
        public string SubscriptionId { get; private set; }

        [JsonProperty("tenantId")]
        public string TenantId { get; private set; }

    }


}
