using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApplication.Models
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
