using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Azure.Functions.Domain
{
    [DataContract]
    public class NarsRequestKey
    {
        [DataMember]
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [DataMember]
        [JsonProperty("force")]
        public bool Force { get; set; }

        [DataMember]
        [JsonProperty("callStatus")]
        public int CallStatus { get; set; }

        [DataMember]
        [JsonProperty("originInfo")]
        public OriginInfo OriginInfo { get; set; }
    }
}
