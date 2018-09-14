using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Azure.Functions.Domain
{
    [DataContract]
    public class Status
    {
        [DataMember]
        [JsonProperty("ErrorCode")]
        public int ErrorCode { get; set; }
        [DataMember]
        [JsonProperty("Exception")]
        public Exception Exception { get; set; }
        [DataMember]
        [JsonProperty("Message")]
        public string Message { get; set; }
        [DataMember]
        [JsonProperty("Result")]
        public int Result { get; set; }
        
    }
}
