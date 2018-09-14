using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Azure.Functions.Domain
{
    [DataContract]
    public class NarsCall
    {
        [DataMember]
        [JsonProperty("AcDura")]
        public string AcDura { get; set; }
        [DataMember]
        [JsonProperty("ActualDurationMinutes")]
        public int? ActualDurationMinutes { get; set; }
        [DataMember]
        [JsonProperty("AdTime")]
        public string AdTime { get; set; }
        [DataMember]
        [JsonProperty("DrTime")]
        public string DrTime { get; set; }
        [DataMember]
        [JsonProperty("acostaNumber")]
        public long AcostaNumber { get; set; }
        [DataMember]
        [JsonProperty("actualDuration")]
        public string ActualDuration { get; set; }
        [DataMember]
        [JsonProperty("adminTime")]
        public int AdminTime { get; set; }
        [DataMember]
        [JsonProperty("assignType")]
        public int AssignType { get; set; }
        [DataMember]
        [JsonProperty("callId")]
        public string CallId { get; set; }
        [DataMember]
        [JsonProperty("completedDate")]
        public DateTime? CompletedDate { get; set; }
        [DataMember]
        [JsonProperty("drivingTime")]
        public int DrivingTime { get; set; }
        [DataMember]
        [JsonProperty("duration")]
        public TimeSpan? Duration { get; set; }
        [DataMember]
        [JsonProperty("id")]
        public string ID { get; set; }
        [DataMember]
        [JsonProperty("initialized")]
        public bool Initialized { get; set; }
        [DataMember]
        [JsonProperty("project")]
        public string Project { get; set; }
        [DataMember]
        [JsonProperty("projectCode")]
        public string ProjectCode { get; set; }
        [DataMember]
        [JsonProperty("projectKey")]
        public string ProjectKey { get; set; }
        [DataMember]
        [JsonProperty("projectName")]
        public string ProjectName { get; set; }
        [DataMember]
        [JsonProperty("reportedDate")]
        public DateTime? ReportedDate { get; set; }
        [DataMember]
        [JsonProperty("resourceCount")]
        public int? ResourceCount { get; set; }
        [DataMember]
        [JsonProperty("resourceNumber")]
        public int? ResourceNumber { get; set; }
        [DataMember]
        [JsonProperty("scheduledDate")]
        public DateTime? ScheduledDate { get; set; }
        [DataMember]
        [JsonProperty("status")]
        public string Status { get; set; }
        [DataMember]
        [JsonProperty("storeAddress")]
        public string StoreAddress { get; set; }
        [DataMember]
        [JsonProperty("storeCity")]
        public string StoreCity { get; set; }
        [DataMember]
        [JsonProperty("storeDistance")]
        public string StoreDistance { get; set; }
        [DataMember]
        [JsonProperty("storeLat")]
        public decimal StoreLat { get; set; }
        [DataMember]
        [JsonProperty("storeLong")]
        public decimal StoreLong { get; set; }
        [DataMember]
        [JsonProperty("storeName")]
        public string StoreName { get; set; }
        [DataMember]
        [JsonProperty("storePhone")]
        public string StorePhone { get; set; }
        [DataMember]
        [JsonProperty("storeState")]
        public string StoreState { get; set; }
        [DataMember]
        [JsonProperty("storeZip")]
        public string StoreZip { get; set; }

        //Convenience Properties.
        [JsonIgnore]
        public string StorePhoneDisplay => string.Format("{0:(###)###.####}", StorePhone);
        [JsonIgnore]
        public string StoreZipDisplay => string.Format("{0:#####-####}", StoreZip);
    }
}
