using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PaymentsFrontEnd.Response
{
    [DataContract]
    public class C2BQueryResponse
    {
        [JsonProperty("BusinessShortCode")]
        public string BusinessShortCode { get; set; }
        [JsonProperty("BillRefNumber")]
        public string BillRefNumber { get; set; }
        [JsonProperty("MSISDN")]
        public string MSISDN { get; set; }
        [JsonProperty("FirstName")]
        public string FirstName { get; set; }
        [JsonProperty("MiddleName")]
        public string MiddleName { get; set; }
        [JsonProperty("LastName")]
        public string LastName { get; set; }
        [JsonProperty("TransID")]
        public string TransID { get; set; }
        [JsonProperty("ThirdPartyTransID")]
        public string ThirdPartyTransID { get; set; }
        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }
        [JsonProperty("TransTime")]
        public string TransTime { get; set; }
        [JsonProperty("InvoiceNumber")]
        public string InvoiceNumber { get; set; }
        [JsonProperty("OrgAccountBalance")]
        public string OrgAccountBalance { get; set; }
        [JsonProperty("TransAmount")]
        public string TransAmount { get; set; }
    }
}