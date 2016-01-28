using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Models
{

    [JsonObject()]
    public class SubscribeResourceData
    {

        [JsonProperty("@odata.type")]
        public string ODataType { get; private set; }

        [JsonProperty("@odata.id")]
        public string ODataId { get; private set; }

        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("organizationId")]
        public string OrganizationId { get; private set; }

        [JsonProperty("sequenceNumber")]
        public long SequenceNumber { get; private set; }

    }

}
