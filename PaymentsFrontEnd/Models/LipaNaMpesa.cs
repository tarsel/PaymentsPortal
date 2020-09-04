using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentsFrontEnd.Models
{
    public class LipaNaMpesa
    {
        public string BusinessShortCode { get; set; }
        public string Amount { get; set; }
        public string PhoneNumber { get; set; }
        public string AccountReference { get; set; }
        public string TransactionDesc { get; set; }
    }
}