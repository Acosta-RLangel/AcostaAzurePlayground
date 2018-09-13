using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Azure.Functions.Domain
{
    [DataContract]
    public class OriginInfo
    {
        [DataMember]
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [DataMember]
        [JsonProperty("localDate")]
        public DateTime LocalDate { get; set; }
    }
}
