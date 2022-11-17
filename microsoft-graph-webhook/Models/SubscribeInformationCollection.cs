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
    public class SubscribeInformationCollection
    {

        public SubscribeInformationCollection()
        {
        }

        [JsonProperty("value")]
        public ICollection<SubscribeInformation> Values { get; private set; }

    }

}
