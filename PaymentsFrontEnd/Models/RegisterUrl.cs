using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace PaymentsFrontEnd.Models
{
    public class RegisterUrl
    {
        public string ShortCode { get; set; }
        public string ResponseType { get; set; }
        public string ConfirmationURL { get; set; }
        public string ValidationURL { get; set; }
    }
}