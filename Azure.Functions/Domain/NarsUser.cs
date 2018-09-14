using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Azure.Functions.Domain
{
    [DataContract]
    public class NarsUser
    {
        [DataMember]
        [JsonProperty("Category")]
        public string Category { get; set; }
        [DataMember]
        [JsonProperty("Country")]
        public string Country { get; set; }
        [DataMember]
        [JsonProperty("Description")]
        public string Description { get; set; }
        [DataMember]
        [JsonProperty("EmailAddress")]
        public string EmailAddress { get; set; }
        [DataMember]
        [JsonProperty("EmployeeNumber")]
        public string EmployeeNumber { get; set; }
        [DataMember]
        [JsonProperty("EmploymentStatus")]
        public string EmploymentStatus { get; set; }
        [DataMember]
        [JsonProperty("ExternalCode")]
        public string ExternalCode { get; set; }
        [DataMember]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [DataMember]
        [JsonProperty("HireDate")]
        public DateTime? HireDate { get; set; }
        [DataMember]
        [JsonProperty("JobTitle")]
        public string JobTitle { get; set; }
        [DataMember]
        [JsonProperty("Language")]
        public string Language { get; set; }
        [DataMember]
        [JsonProperty("LastLogonDate")]
        public DateTime? LastLogonDate { get; set; }
        [DataMember]
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [DataMember]
        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }
        [DataMember]
        [JsonProperty("NumberHoursPerWeek")]
        public int? NumberHoursPerWeek { get; set; }
        [DataMember]
        [JsonProperty("PrimaryCity")]
        public string PrimaryCity { get; set; }
        [DataMember]
        [JsonProperty("PrimaryPhone")]
        public string PrimaryPhone { get; set; }
        [DataMember]
        [JsonProperty("PrimaryState")]
        public string PrimaryState { get; set; }
        [DataMember]
        [JsonProperty("PrimaryStreet1")]
        public string PrimaryStreet1 { get; set; }
        [DataMember]
        [JsonProperty("PrimaryStreet2")]
        public string PrimaryStreet2 { get; set; }
        [DataMember]
        [JsonProperty("SecondaryCity")]
        public string SecondaryCity { get; set; }
        [DataMember]
        [JsonProperty("SecondaryPhone")]
        public string SecondaryPhone { get; set; }
        [DataMember]
        [JsonProperty("SecondaryState")]
        public string SecondaryState { get; set; }
        [DataMember]
        [JsonProperty("SecondaryStreet1")]
        public string SecondaryStreet1 { get; set; }
        [DataMember]
        [JsonProperty("SecondaryStreet2")]
        public string SecondaryStreet2 { get; set; }
        [DataMember]
        [JsonProperty("Status")]
        public Status Status { get; set; }
        [DataMember]
        [JsonProperty("SupervisorEmployeeNumber")]
        public string SupervisorEmployeeNumber { get; set; }
        [DataMember]
        [JsonProperty("TerminationDate")]
        public DateTime? TerminationDate { get; set; }
        [DataMember]
        [JsonProperty("Version")]
        public int Version { get; set; }
        [DataMember]
        [JsonProperty("WorkPhone")]
        public string WorkPhone { get; set; }
        [DataMember]
        [JsonProperty("Zip")]
        public string Zip { get; set; }
        [DataMember]
        [JsonProperty("userName")]
        public string UserName { get; set; }
        

    }
}
